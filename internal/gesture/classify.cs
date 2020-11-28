using Leap;
using Global;

public class Classify : IClassify {

    private IVectorHelper vh;

    public Classify(IVectorHelper vecH) {
        vh = vecH;
    }

    public bool IsGesture(Joints range) {
        var check = GBL.NO_GESTURE_RANGE;





        return false;
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