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
        Classify classify = new Classify(new VectorHelper());

        for (;;) {
            dm.Extract(c.Frame());
            System.Threading.Thread.Sleep(20);

            var positions = dm.positions();
            
            if(positions.right.Count == Global.GBL.N_SAMPLES) {
                var rangeRight = s.range(positions.right);
                var velocities = dm.velocities();
                
                if ( classify.IsMovement(rangeRight)) {
                    // Console.WriteLine(positions.right[Global.GBL.N_SAMPLES - 2].ToString());
                    // Console.WriteLine(rangeRight);

                    if ( classify.IsTap(rangeRight, s.average(velocities.right), s.range(velocities.right)) ){
                        Console.WriteLine("Tap!");
                    }

                }


            }
            



        }

    }

}