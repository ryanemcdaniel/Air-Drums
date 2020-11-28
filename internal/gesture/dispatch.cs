using Leap;
using Global;

public class Gesture : IGesture {

    private Controller c;
    private IDataManager dm;
    private IStats s;

    public Gesture(Controller controller, IDataManager dataManager, IStats stats){
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