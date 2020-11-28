using Leap;
using System.Collections.Generic;

public interface IDataManager {
    public void extract(Frame f);
    public (List<Joints> left, List<Joints> right) positions();
    public (List<Joints> left, List<Joints> right) velocities();
}

public class DataManager : IDataManager {

    private IQueues left;
    private IQueues right;

    public DataManager(IQueues l, IQueues r){
        left = l;
        right = r;
    }

    public void extract(Frame f){
        foreach(var h in f.Hands){
            if(h.IsLeft) left.LoadSample(h, f.CurrentFramesPerSecond);
            else right.LoadSample(h, f.CurrentFramesPerSecond); 
        }
    }

    public (List<Joints> left, List<Joints> right) positions() => (left.GetPositions(), right.GetPositions());
    public (List<Joints> left, List<Joints> right) velocities() => (left.GetVelocities(), right.GetVelocities());
}