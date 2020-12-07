using System.Collections.Generic;

public interface IClassify {
    
    public bool IsMovement(List<Joints> pos);

    public bool IsTap(List<Joints> pos, List<Joints> vel);

    public (bool swiped, bool direction) IsSwipe();

    public bool IsRecord();

}