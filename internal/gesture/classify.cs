using System.Collections.Generic;
using System;
using Global;

public class Classify : IClassify {

    private IVectorHelper vh;
    private IStats stats;
    private int n_lookback;
    private int n_lookback2;
    private int n_samples;
    private List<Joints> pos;
    private List<Joints> vel;

    public Classify(IVectorHelper vecH, IStats stats) {
        vh = vecH;
        this.stats = stats;
        n_lookback = GBL.N_LOOKBACK;
        n_samples = GBL.N_SAMPLES;
        n_lookback2 = GBL.N_LOOKBACK;
    }

    public void Update(List<Joints> position, List<Joints> velocity) {
        pos = position;
        vel = velocity;
    }

    public bool IsMovement() {
        if(pos.Count != n_samples) return false;
        var range = stats.range(pos);
        foreach (var v in range.ToArray()){
            var checks = vh.greaterEqual(v, GBL.GES_POS_RANGE);
            if (checks.x || checks.y || checks.z) return true;
        }
        return false;
    }

    public bool IsTap() {
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

        var prevVel = vh.average(vel[n_samples - 2].TipsNoThumb()).y;
        if (curVel < prevVel) VelocityLookback(curVel);
        else {
            var lookbackList = vel.GetRange(n_samples - n_lookback, n_lookback);
            
            var velAve = vh.average(stats.average(lookbackList).TipsNoThumb()).y;
            if (velAve > -100) {
                LookbackReset();
                return false;
            }

            var finalVelRange = vh.average(stats.range(lookbackList).TipsNoThumb()).y;
            if (finalVelRange > 100.0f) {
                LookbackReset();
                return false;
            }

            LookbackReset();
            return true;
        };
        return false;
    }

    public bool IsSwipe() {

        var range = stats.range(pos);
        foreach (var p in stats.range(pos).ToArray()) {
            if (p.y > 30) return false;
        }
        
        var curVel = vh.average(vel[n_samples - 1].TipsNoThumb()).x;
        var prevVel = vh.average(vel[n_samples - 2].TipsNoThumb()).x;

        if (prevVel > 0 ^ curVel > 0) {
            LookbackReset2();
            return false;
        }

        

        return false;
    }

    public bool IsSwipeLeft() {
        return false;
    }

    public bool IsStop() {
        
        // Check for palm being lowest joint
        var curPalmPos = pos[n_samples - 1].palm;
        foreach (var p in pos[n_samples - 1].ToArray()){
            var check = vh.greaterEqual(curPalmPos, p);
            if (check.y) return false;
        }

        // Check for low z range across current hand
        var vectors = pos[n_samples -1].ToArray();
        (var min, var max) = (vectors[0], vectors[0]);
        foreach (var v in vectors) {
            (min, max) = vh.minMax(min, max, v);
        }
        Console.WriteLine(vh.sub(max, min).ToString());
        if (vh.sub(max, min).z > 20) return false;

        return true;
    }

    public void VelocityLookback(float v) {
        if (n_lookback == 1) return;
        if (v < 0) n_lookback = 1;
    }

    public void LookbackReset() {
        n_lookback = n_samples - 1;
    }

    public void VelocityLookback2(float v) {
        if (n_lookback2 == 1) return;
        if (v < 0) n_lookback2 = 1;
    }

    public void LookbackReset2() {
        n_lookback2 = n_samples - 1;
    }

}