using System.Collections.Generic;

public class Swipe : IGesture {

    public Swipe() {

    }

    public bool Happened(List<Joints> pos, List<Joints> vel) {
        return false;
    }

    public bool IsLeft() {
        return false;
    }

    public void AdjustLookback() {

    }

    public void ResetLookback() {

    }

}

