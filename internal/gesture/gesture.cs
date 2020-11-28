using System;
using Leap;

public class Gesture {

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
            (var l, var r) = dm.positions();
            if(l.Count > 1){
                Console.Write(l[0].palm.ToString() + "\n");
            }
            if(r.Count > 1){
                Console.Write(r[0].palm.ToString() + "\n");
            }    
        }

    }

}