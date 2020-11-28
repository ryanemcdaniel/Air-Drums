using Leap;
using Global;
using System.Collections.Generic;

public class Classify : IClassify {

    private IVectorHelper vh;

    public Classify(IVectorHelper vecH) {
        vh = vecH;
    }

    public bool IsGesture(Joints range) {
        var flag = false;

        foreach (var v in range.ToArray()){
            var checks = vh.greaterEqual(v, GBL.NO_GESTURE_RANGE);
            if (checks.x || checks.y || checks.z) flag = true;
        }
        
        return flag;
    }

    public bool IsTap() {
        return false;
    }


    public (bool isSwipe, bool direction) IsSwipe() {
        return (false, false);
    }

    public bool IsRecord() {
        return false;
    }

}