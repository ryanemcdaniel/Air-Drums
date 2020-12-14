using Leap;
using Ultrahaptics;
using MIDI = TobiasErichsen.teVirtualMIDI.TeVirtualMIDI;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using air_drums;

public class Air_Drums {

    public static void Main(){
        
        Thread newWindowThread = new Thread(new ThreadStart(() =>  
        {  
            // create and show the window
            App obj = new App();   

            // start the Dispatcher processing  
            System.Windows.Threading.Dispatcher.Run();  
        }));  

        newWindowThread.SetApartmentState(ApartmentState.STA);  
        newWindowThread.IsBackground = true;  
        newWindowThread.Start();  

        // Connect to LeapMotion Controller
        Console.WriteLine("Initializing Leap...");
        var leapMotion = new Controller();
        do {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(".");
        } while (!leapMotion.IsConnected);
        Console.WriteLine("Leap ready.");

        // Connect to UHDK5 ultrasonic emitters
        Console.WriteLine("Initializing UHDK5...");
        var uhdk5 = new AmplitudeModulationEmitter();
        Console.WriteLine("UHDK5 ready.");
        Console.WriteLine("Dog Friendly Mode: " + GBL.DOG_FRIENDLY);

        // Connect virtual MIDI ports
        Console.WriteLine("Initializing virtual MIDI ports...");
        MIDI.logging(MIDI.TE_VM_LOGGING_MISC | MIDI.TE_VM_LOGGING_RX | MIDI.TE_VM_LOGGING_TX);
        var leftManu = new Guid("aa4e075f-3504-4aab-9b06-9a4104a91cf0");
        var leftProd = new Guid("bb4e075f-3504-4aab-9b06-9a4104a91cf0");
        var leftMIDI = new MIDI("Air Drums Left Hand", 65535, MIDI.TE_VM_FLAGS_PARSE_RX, ref leftManu, ref leftProd);
        var rightManu = new Guid("cc4e075f-3504-4aab-9b06-9a4104a91cf0");
        var rightProd = new Guid("dd4e075f-3504-4aab-9b06-9a4104a91cf0");
        var rightMIDI = new MIDI("Air Drums Right Hand", 65535, MIDI.TE_VM_FLAGS_PARSE_RX, ref rightManu, ref rightProd);
        Console.WriteLine("MIDI resources ready.");

        // Haptics resources
        var hapticTargets = new List<AmplitudeModulationControlPoint>();
        var hapticTimes = new List<int>();
        var hapticVH = new VectorHelper();
        var hapticJH = new JointsHelper(hapticVH);
        var haptic = new Haptic(hapticJH, uhdk5);

        // MIDI resources
        var leftComTable = new Commands(true);
        var leftNotes = new List<int>();
        var leftTimes = new List<int>();
        var leftPort = new Port(leftMIDI);
        var rightComTable = new Commands(false);
        var rightNotes = new List<int>();
        var rightTimes = new List<int>();
        var rightPort = new Port(rightMIDI);

        // Classification resources
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

        // Concurrency structures
        var leftFrameStream = new ConcurrentQueue<Frame>();
        var leftCommandStream = new ConcurrentQueue<int>();
        var rightFrameStream = new ConcurrentQueue<Frame>();
        var rightCommandStream = new ConcurrentQueue<int>();
        var hapticStream = new ConcurrentQueue<Joints>();
        
        // Processes
        var data = new Proc_Data(leapMotion, leftFrameStream, rightFrameStream) as IProc;
        var leftGesture = new Proc_Gesture(leftClassify, leftDataManager, leftVH, leftFrameStream, leftCommandStream, hapticStream) as IProc;
        var leftCommand = new Proc_MIDI(leftPort, leftCommandStream, leftNotes, leftTimes, leftComTable) as IProc;
        var rightGesture = new Proc_Gesture(rightClassify, rightDataManager, rightVH, rightFrameStream, rightCommandStream, hapticStream) as IProc;
        var rightCommand = new Proc_MIDI(rightPort, rightCommandStream, rightNotes, rightTimes, rightComTable) as IProc;
        var haptics = new Proc_Haptics(haptic, hapticStream, hapticTargets, hapticTimes) as IProc;

        // Instantiate threads with looped pipelines
        var dataThread = new Thread(data.Loop);
        var leftGestureThread = new Thread(leftGesture.Loop);
        var rightGestureThread = new Thread(rightGesture.Loop);
        var leftCommandThread = new Thread(leftCommand.Loop);
        var rightCommandThread = new Thread(rightCommand.Loop);
        var hapticsThread = new Thread(haptics.Loop);

        // Start threads
        dataThread.Start();
        leftGestureThread.Start();
        rightGestureThread.Start();
        leftCommandThread.Start();
        rightCommandThread.Start();
        hapticsThread.Start();
    }
}