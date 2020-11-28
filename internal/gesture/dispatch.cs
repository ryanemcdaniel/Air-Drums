using Leap;

public class Dispatch : IDispatch {

    private Controller c;
    private IDataManager dm;

    public Dispatch(Controller controller, IDataManager dataManager){
        c = controller;
        dm = dataManager;
    }
    
    public void printOuts(){
        
        for (;;) {
            dm.Extract(c.Frame());
            System.Threading.Thread.Sleep(20);
        }

    }

}