using Leap;


public interface IDataManager {
    public void Extract(Frame f);
}

public class DataManager : IDataManager {

    public IQueues left;
    public IQueues right;

    public DataManager(IQueues l, IQueues r){
        left = l;
        right = r;
    }

    public void Extract(Frame f){

    }

}