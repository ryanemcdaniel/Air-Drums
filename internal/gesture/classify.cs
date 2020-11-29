using System;
using Leap;
using Global;
using System.Collections.Generic;

public class Classify : IClassify {

    private IVectorHelper vh;
    private IStats s;

    public Classify(IVectorHelper vecH, IStats stats) {
        vh = vecH;
        s = stats;
    }

    public bool IsMovement(List<Joints> pos) {
        var flag = false;
        var range = s.range(pos);
        foreach (var v in range.ToArray()){
            var checks = vh.greaterEqual(v, GBL.NO_GESTURE_RANGE);
            if (checks.x || checks.y || checks.z) flag = true;
        }
        
        return flag;
    }

    public bool IsTap(List<Joints> pos, List<Joints> vel) {
        var posRange = s.range(pos);
        foreach (var v in posRange.TipsNoThumb()) {
            var checks = vh.greaterEqual(v, GBL.TAP_POS_RANGE);
            if (checks.x || !checks.y || checks.z) return false;
        }

        Console.WriteLine("Check:  pos range");

        var velAve = s.average(vel);
        foreach (var v in velAve.TipsNoThumb()) {
            var checks = vh.greaterEqual(v, GBL.TAP_VEL_AVE);
            if (checks.y) return false;
        }

        Console.WriteLine("Check:  vel ave");

        var velRange = s.range(vel.GetRange(GBL.N_SAMPLES - 3, 2));
        foreach (var v in velRange.TipsNoThumb()) {
            var checks = vh.greaterEqual(v, GBL.TAP_VEL_RANGE);
            if (checks.y) return false;
        }

        return true;
    }


    public (bool swiped, bool direction) IsSwipe() {
        return (false, false);
    }

    public bool IsRecord() {
        return false;
    }

}