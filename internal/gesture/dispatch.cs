using Leap;
using System;

public class Dispatch : IDispatch {

    private Controller c;
    private IDataManager dm;

    public Dispatch(Controller controller, IDataManager dataManager){
        c = controller;
        dm = dataManager;
    }
    
    public void printOuts(){
        Stats s = new Stats(new JointsHelper(new VectorHelper()));
        Classify classify = new Classify(new VectorHelper());

        for (;;) {
            dm.Extract(c.Frame());
            System.Threading.Thread.Sleep(20);


            var positions = dm.positions();
            
            if(positions.right.Count == Global.GBL.N_SAMPLES) {
                var rangeRight = s.range(positions.right);
                Console.WriteLine(classify.IsGesture(rangeRight));
            }
            
        }

    }

}