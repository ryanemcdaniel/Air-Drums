using System.Collections.Generic;

public interface IGesture {
    bool Happened(List<Joints> pos, List<Joints> vel);
    void AdjustLookback();
    void ResetLookback();
}