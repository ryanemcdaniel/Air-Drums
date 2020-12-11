using System.Collections.Generic;

public class Stop : IGesture {

    public bool Happened(List<Joints> pos, List<Joints> vel) {
        return false;
    }

    public void AdjustLookback() {

    }

    public void ResetLookback() {

    }

}