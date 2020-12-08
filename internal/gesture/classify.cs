using System;
using Leap;
using Global;
using System.Collections.Generic;

public class Classify : IClassify {

    private IVectorHelper vh;
    private IStats s;
    private List<Joints> pos;
    private List<Joints> vel;
    private int lookback;

    public Classify(IVectorHelper vecH, IStats stats) {
        vh = vecH;
        s = stats;
        lookback = GBL.N_LOOKBACK;
    }

    public bool IsMovement(List<Joints> positions) {
        
        // Do not classify movements until enough samples have loaded
        if(positions.Count != GBL.N_SAMPLES) return false;

        // Small position change in detection window rejection
        var range = s.range(positions);
        foreach (var v in range.ToArray()){
            var checks = vh.greaterEqual(v, GBL.NO_GESTURE_RANGE);
            if (checks.x || checks.y || checks.z) return true;
        }
        return false;
    }

    public bool IsTap(List<Joints> pos, List<Joints> vel) {

        // Positive velocity rejection
        var curVel = vh.average(vel[GBL.N_SAMPLES - 1].TipsNoThumb()).y;
        if (curVel > 0) return false;

        // Finger tips above palm rejection
        var curPosPalm = pos[GBL.N_SAMPLES -1].palm;
        var posCheck = vh.greaterEqualListOnetoMany(pos[GBL.N_SAMPLES - 1].TipsNoThumb(), curPosPalm);
        foreach (var c in posCheck) if(c.y) {
            return false;
        };

        // Zero acceleration rejection
        var velRange = vh.average(s.range(vel).TipsNoThumb()).y;
        if (velRange < 150) {
            return false;
        };

        // Velocity lookback attenuation
        var prevVel = vh.average(vel[GBL.N_SAMPLES - 2].TipsNoThumb()).y;
        if (curVel < prevVel) GBL.VelocityLookback(curVel);

        // Iterative deceleration rejection
        else {
            
            // Find lookback values
            var lookback = vel.GetRange(GBL.LookbackStart(), GBL.N_LOOKBACK);
            
            // Low velocity 
            var velAve = vh.average(s.average(lookback).TipsNoThumb()).y;
            if (velAve > -100) {
                GBL.LookbackReset();
                return false;
            }

            // Reject 
            var finalVelRange = vh.average(s.range(lookback).TipsNoThumb()).y;
            if (finalVelRange > 100.0f) {
                GBL.LookbackReset();
                return false;
            }

            // Accept moment of deceleration
            GBL.LookbackReset();
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

}