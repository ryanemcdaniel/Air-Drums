using System.Collections.Generic;

public interface IClassify {
    void Update(List<Joints> position, List<Joints> velocity);
    bool IsMovement();
    bool IsTap();
    bool IsSwipeRight();
    bool IsSwipeLeft();
    bool IsStop();
}