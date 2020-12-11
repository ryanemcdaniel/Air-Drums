using System.Collections.Generic;

public interface IClassify {

    public void Update(List<Joints> position, List<Joints> velocity);
    
    public bool IsMovement();

    public bool IsTap();

    public bool IsSwipe();

    public bool IsSwipeLeft();

    public bool IsStop();

}