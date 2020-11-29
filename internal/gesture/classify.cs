using System;
using Leap;
using Global;
using System.Collections.Generic;

public class Classify : IClassify {

    private IVectorHelper vh;

    public Classify(IVectorHelper vecH) {
        vh = vecH;
    }

    public bool IsMovement(Joints range) {
        var flag = false;

        foreach (var v in range.ToArray()){
            var checks = vh.greaterEqual(v, GBL.NO_GESTURE_RANGE);
            if (checks.x || checks.y || checks.z) flag = true;
        }
        
        return flag;
    }

    public bool IsTap(Joints positionRange, Joints velocityAve, Joints velocityRange) {
        
        // Console.WriteLine(positionRange.ToString());

        foreach (var v in positionRange.Tips()){
            var checks = vh.greaterEqual(v, GBL.TAP_POS_RANGE);
            if (checks.x || !checks.y || checks.z) return false;
        }

        Console.WriteLine("Pos range satisfied");

        foreach (var v in velocityAve.Tips()){
            var checks = vh.greaterEqual(v, GBL.TAP_VEL_AVE);
            if (!checks.y) return false;
        }

        Console.WriteLine(velocityRange.ToString());

        foreach (var v in velocityRange.Tips()){
            var checks = vh.greaterEqual(v, GBL.TAP_VEL_RANGE);
            if (checks.y) return false;
        }

        return true;
    }


    public (bool isSwipe, bool direction) IsSwipe() {
        return (false, false);
    }

    public bool IsRecord() {
        return false;
    }

}