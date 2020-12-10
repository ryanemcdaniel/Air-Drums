using System;
using Leap;
using Ultrahaptics;
using System.Collections.Generic;
using System.Collections.Concurrent;
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

        Console.WriteLine("Initializing UHDK5...");
        var uhdk5 = new AmplitudeModulationEmitter();
        Console.WriteLine("UHDK5 ready.");
        Console.WriteLine("Dog Friendly Mode: " + GBL.DOG_FRIENDLY);

        Console.WriteLine("Initializing virtual MIDI ports...");
        TeVirtualMIDI.logging(TeVirtualMIDI.TE_VM_LOGGING_MISC | TeVirtualMIDI.TE_VM_LOGGING_RX | TeVirtualMIDI.TE_VM_LOGGING_TX);
        Console.WriteLine("MIDI:  system flags set...");
        var leftManu = new Guid("aa4e075f-3504-4aab-9b06-9a4104a91cf0");
        var leftProd = new Guid("bb4e075f-3504-4aab-9b06-9a4104a91cf0");
        var leftMIDI = new TeVirtualMIDI("C# loopback", 65535, TeVirtualMIDI.TE_VM_FLAGS_PARSE_RX, ref leftManu, ref leftProd);
        Console.WriteLine("MIDI:  left hand port ready...");
        var rightManu = new Guid("cc4e075f-3504-4aab-9b06-9a4104a91cf0");
        var rightProd = new Guid("dd4e075f-3504-4aab-9b06-9a4104a91cf0");
        var rightMIDI = new TeVirtualMIDI("C# loopback", 65535, TeVirtualMIDI.TE_VM_FLAGS_PARSE_RX, ref rightManu, ref rightProd);
        Console.WriteLine("MIDI:  right hand port ready...");
        Console.WriteLine("MIDI resources ready.");

        // Instantiate per thread resources
        Console.WriteLine("Initializing haptics thread resources...");
        var hapticTargets = new List<AmplitudeModulationControlPoint>();
        var hapticTimes = new List<int>();
        var hapticVH = new VectorHelper();
        var hapticJH = new JointsHelper(hapticVH);
        var haptic = new Haptic(hapticJH, uhdk5);
        Console.WriteLine("Haptics thread resources ready.");

        Console.WriteLine("Initializing MIDI threads resources...");
        var leftComTable = new Commands(true);
        var leftNotes = new List<int>();
        var leftTimes = new List<int>();
        var leftPort = new Port(leftMIDI);
        var rightComTable = new Commands(true);
        var rightNotes = new List<int>();
        var rightTimes = new List<int>();
        var rightPort = new Port(rightMIDI);
        Console.WriteLine("MIDI threads resources ready.");

        Console.WriteLine("Initializing classification threads resources...");
        var leftVH = new VectorHelper();
        var leftJH = new JointsHelper(leftVH);
        var leftStats = new Stats(leftJH);
        var leftClassify = new Classify(leftVH, leftStats);
        var leftQueues = new Queues(leftJH);
        var leftDataManager = new DataManager(leftQueues, true);
        var rightVH = new VectorHelper();
        var rightJH = new JointsHelper(rightVH);
        var rightStats = new Stats(rightJH);
        var rightClassify = new Classify(rightVH, rightStats);
        var rightQueues = new Queues(rightJH);
        var rightDataManager = new DataManager(rightQueues, false);
        Console.WriteLine("Classification threads resources ready.");

        // Concurrency structures
        var leftFrameStream = new ConcurrentQueue<Frame>();
        var leftCommandStream = new ConcurrentQueue<int>();
        var rightFrameStream = new ConcurrentQueue<Frame>();
        var rightCommandStream = new ConcurrentQueue<int>();
        var hapticStream = new ConcurrentQueue<Joints>();
        
        // Threads
        var data = new Proc_Data(leapMotion, leftFrameStream, rightFrameStream);
        var leftGesture = new Proc_Gesture(leftClassify, leftDataManager, leftVH, leftFrameStream, leftCommandStream, hapticStream);
        var rightGesture = new Proc_Gesture(rightClassify, rightDataManager, rightVH, rightFrameStream, rightCommandStream, hapticStream);
        var leftCommand = new Proc_MIDI(leftPort, leftCommandStream, leftNotes, leftTimes, leftComTable);
        var rightCommand = new Proc_MIDI(rightPort, rightCommandStream, rightNotes, rightTimes, rightComTable);
        var haptics = new Proc_Haptics(haptic, hapticStream, hapticTargets, hapticTimes);

        var dataThread = new Thread(data.PollCamera);
        var leftGestureThread = new Thread(leftGesture.ClassificationPipeline);
        var rightGestureThread = new Thread(rightGesture.ClassificationPipeline);
        var leftCommandThread = new Thread(leftCommand.DispatchMIDI);
        var rightCommandThread = new Thread(rightCommand.DispatchMIDI);
        var hapticsThread = new Thread(haptics.EmissionPipeline);
        dataThread.Start();
        leftGestureThread.Start();
        rightGestureThread.Start();
        leftCommandThread.Start();
        rightCommandThread.Start();
        hapticsThread.Start();
    }
}