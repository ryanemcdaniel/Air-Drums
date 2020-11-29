using Leap;
using System;
using System.Collections.Generic;

public class Dispatch : IDispatch {

    private Controller c;
    private IDataManager dm;

    public Dispatch(Controller controller, IDataManager dataManager){
        c = controller;
        dm = dataManager;
    }
    
    public void printOuts(){
        Stats s = new Stats(new JointsHelper(new VectorHelper()));
        Classify gesture = new Classify(new VectorHelper(), s);

        for (;;) {
            dm.Extract(c.Frame());
            System.Threading.Thread.Sleep(20);

            var pos = dm.positions();
            var vel = dm.velocities();

            if(pos.right.Count != Global.GBL.N_SAMPLES) continue;

            if(gesture.IsMovement(pos.right)){

                if(gesture.IsTap(pos.right, vel.right)){
                    Console.WriteLine("Tap!");
                }

            }
        }

    }

}