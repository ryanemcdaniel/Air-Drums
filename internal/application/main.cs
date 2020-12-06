using System;
using Leap;
using Ultrahaptics;
using System.Collections.Generic;
using Global;
using System.Threading;


public class Air_Drums {

    public static void Main(){
/*
        Console.WriteLine("Initializing Leap");
        Controller leapMotion = new Controller();
        do {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(".");
        } while (!leapMotion.IsConnected);

        VectorHelper vh = new VectorHelper();
        JointsHelper jh = new JointsHelper(vh);
        Queues leftHand  = new Queues(jh);
        Queues rightHand = new Queues(jh);
        DataManager dm = new DataManager(leftHand, rightHand);
        Dispatch threader = new Dispatch(leapMotion, dm);
        threader.printOuts();
    }*/
    Data_Generator dg = new Data_Generator();
    Hand_Generator hg = new Hand_Generator(dg);
    VectorHelper vh = new VectorHelper();
    JointsHelper jh = new JointsHelper(vh);
    GBL.UH_INTENSITY = 1.0f;
    GBL.UH_FREQUENCY = 200.0f;
    AmplitudeModulationEmitter emitter = new AmplitudeModulationEmitter();
    Haptic kit = new Haptic(jh,emitter);

    var Fingers = hg.newFingerList();
    var Hand = hg.newHand(Fingers);
    var points = kit.AquireTarget(Hand);
    kit.updateEmitter(points,emitter);
    //System.Threading.Thread.Sleep(1000);
    emitter.stop();
    emitter.Dispose();
    emitter = null;
    }
}