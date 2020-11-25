using Leap;


public interface IDataManager {
    public void Extract(Frame f);
}

public class DataManager : IDataManager {

    private IQueues left;
    private IQueues right;

    public DataManager(IQueues l, IQueues r){
        left = l;
        right = r;
    }

    public void Extract(Frame f){
        foreach(var h in f.Hands){
            if(h.IsLeft) left.LoadSample(h, f.CurrentFramesPerSecond);
            else right.LoadSample(h, f.CurrentFramesPerSecond); 
        }

    }

}