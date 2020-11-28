using System;
using Leap;
using Ultrahaptics;

public class Air_Drums {

    public static void Main(){

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
        Stats s = new Stats(jh);
        Gesture recognizer = new Gesture(leapMotion, dm, s);
        recognizer.printOuts();
    }
}