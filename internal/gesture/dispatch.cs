using Leap;
using System;
using System.Collections.Generic;
using Ultrahaptics;

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

        AmplitudeModulationEmitter emitter = new AmplitudeModulationEmitter();
        Haptic haptic = new Haptic(new JointsHelper(new VectorHelper()), emitter);
        Port midi = new Port();

        for (;;) {
            dm.Extract(c.Frame());
            System.Threading.Thread.Sleep(20);

            var pos = dm.positions();
            var vel = dm.velocities();

            

            if(gesture.IsMovement(pos.right)){

                if(gesture.IsTap(pos.right, vel.right)){
                    Console.WriteLine("Tap!");
                    var target = haptic.AquireTarget(c.Frame().Hands[0]);
                    haptic.updateEmitter(target);
                    System.Threading.Thread.Sleep(50);
                    midi.playNote();
                    emitter.stop();
                }

            }

            if(gesture.IsMovement(pos.left)){

                if(gesture.IsTap(pos.left, vel.left)){
                    Console.WriteLine("Tap!");
                    var target = haptic.AquireTarget(c.Frame().Hands[1]);
                    haptic.updateEmitter(target);
                    midi.playNote2();
                    System.Threading.Thread.Sleep(50);
                    emitter.stop();
                }

            }
        }

    }

}