using System;
using Leap;
using Global;
using System.Collections.Generic;

public class Classify : IClassify {

    private IVectorHelper vh;
    private IStats stats;
    private int n_lookback;
    private int n_samples;

    public Classify(IVectorHelper vecH, IStats stats) {
        vh = vecH;
        this.stats = stats;
        n_lookback = GBL.N_LOOKBACK;
        n_samples = GBL.N_SAMPLES;
    }

    public bool IsMovement(List<Joints> positions) {
        
        // Do not classify movements until enough samples have loaded
        if(positions.Count != n_samples) return false;

        // Small position change in detection window rejection
        var range = stats.range(positions);
        foreach (var v in range.ToArray()){
            var checks = vh.greaterEqual(v, GBL.GES_POS_RANGE);
            if (checks.x || checks.y || checks.z) return true;
        }
        return false;
    }

    public bool IsTap(List<Joints> pos, List<Joints> vel) {

        // Positive velocity rejection
        var curVel = vh.average(vel[n_samples - 1].TipsNoThumb()).y;
        if (curVel > 0) return false;

        // Finger tips above palm rejection
        var curPosPalm = pos[n_samples -1].palm;
        var posCheck = vh.greaterEqualListOnetoMany(pos[n_samples - 1].TipsNoThumb(), curPosPalm);
        foreach (var c in posCheck) if(c.y) {
            return false;
        };

        // Zero acceleration rejection
        var velRange = vh.average(stats.range(vel).TipsNoThumb()).y;
        if (velRange < 150) {
            return false;
        };

        // Velocity lookback attenuation
        // Increasing velocity means more weight on recent velocities
        var prevVel = vh.average(vel[n_samples - 2].TipsNoThumb()).y;
        if (curVel < prevVel) VelocityLookback(curVel);

        // Iterative deceleration rejection
        else {
            
            // Find lookback values
            var lookbackList = vel.GetRange(n_samples - n_lookback, n_lookback);
            
            // Low velocity on deceleration rejection
            var velAve = vh.average(stats.average(lookbackList).TipsNoThumb()).y;
            if (velAve > -100) {
                LookbackReset();
                return false;
            }

            // Consistent deceleration rejection
            var finalVelRange = vh.average(stats.range(lookbackList).TipsNoThumb()).y;
            if (finalVelRange > 100.0f) {
                LookbackReset();
                return false;
            }

            // Accept first moment of deceleration
            LookbackReset();
            return true;

        };
        return false;
    }

    public (bool swiped, bool direction) IsSwipe() {
        return (false, false);
    }

    public bool IsRecord() {
        return false;
    }

    public void VelocityLookback(float v) {
        if (GBL.N_LOOKBACK == 1) return;
        if (v < 0) GBL.N_LOOKBACK = 1;
    }

    public void LookbackReset() {
        n_lookback = n_samples - 1;
    }

}