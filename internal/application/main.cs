using System;
using Leap;
using Ultrahaptics;
using System.Collections.Generic;
using Global;
using System.Threading;


public class Air_Drums {

    public static void Main(){

        Console.WriteLine("Initializing Leap...");
        Controller leapMotion = new Controller();
        do {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(".");
        } while (!leapMotion.IsConnected);
        Console.WriteLine("Leap ready.");


    }
}