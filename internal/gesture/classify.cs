using Leap;

public class Classify : IClassify {

    public IStats s;

    public Classify(IStats stats){
        s = stats;
    }

    public bool NoGesture() {
        
        




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