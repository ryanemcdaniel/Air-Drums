using System.Security.AccessControl;
using Leap;
using System.Collections.Generic;

public interface IDataManager {
    public void Extract(Frame f);
    public (List<Joints> left, List<Joints> right) positions();
    public (List<Joints> left, List<Joints> right) velocities();
}