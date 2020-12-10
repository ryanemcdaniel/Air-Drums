using System;
using Leap;
using Ultrahaptics;
using System.Collections.Generic;
using Global;
using System.Threading;
using TobiasErichsen.teVirtualMIDI;


public class Air_Drums {

    public static void Main(){

        // TODO run and exit config tool before any other code executes


        // Get main IO routes initialized
        Console.WriteLine("Initializing Leap...");
        var leapMotion = new Controller();
        do {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(".");
        } while (!leapMotion.IsConnected);
        Console.WriteLine("Leap ready.");

        Console.WriteLine("Initializing Ultrahaptics...");
        var uhdk5 = new AmplitudeModulationEmitter();
        Console.WriteLine("Ultrahaptics ready.");
        Console.WriteLine("Dog Friendly Mode: " + GBL.DOG_FRIENDLY);

        Console.WriteLine("Initializing virtual MIDI ports...");
        TeVirtualMIDI.logging(TeVirtualMIDI.TE_VM_LOGGING_MISC | TeVirtualMIDI.TE_VM_LOGGING_RX | TeVirtualMIDI.TE_VM_LOGGING_TX);
        Console.WriteLine("MIDI:  system flags set...");
        var leftManu = new Guid("aa4e075f-3504-4aab-9b06-9a4104a91cf0");
        var leftProd = new Guid("bb4e075f-3504-4aab-9b06-9a4104a91cf0");
        var leftPort = new TeVirtualMIDI("C# loopback", 65535, TeVirtualMIDI.TE_VM_FLAGS_PARSE_RX, ref leftManu, ref leftProd);
        Console.WriteLine("MIDI:  left hand port ready...");
        var rightManu = new Guid("cc4e075f-3504-4aab-9b06-9a4104a91cf0");
        var rightProd = new Guid("dd4e075f-3504-4aab-9b06-9a4104a91cf0");
        var rightPort = new TeVirtualMIDI("C# loopback", 65535, TeVirtualMIDI.TE_VM_FLAGS_PARSE_RX, ref rightManu, ref rightProd);
        Console.WriteLine("MIDI:  right hand port ready...");
        Console.WriteLine("MIDI resources ready.");

        // Instantiate thread resources
        Console.WriteLine("Initializing right hand thread resources...");
        var rightVH = new VectorHelper();




    }
}