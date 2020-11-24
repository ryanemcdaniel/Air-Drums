using System;
using System.Diagnostics;
using System.Collections.Generic;
using Ultrahaptics;
using Leap;

public struct ButtonWidget
{
    public float radius;
    public float angle;
}

public static class MathF
{
    public static Func<double, float> Cos = angleR => (float)Math.Cos(angleR);
    public static Func<double, float> Sin = angleR => (float)Math.Sin(angleR);
}

// This example creates a static focal point at a frequency of 200Hz, 20cm above the device.
public class ButtonExample
{

    const float PI = (float)Math.PI;

    public static void Main(string[] args)
    {

        // Create an emitter, which connects to the first connected device
        AmplitudeModulationEmitter emitter = new AmplitudeModulationEmitter();

        // Create an aligment object which relates the tracking and device spaces
        Alignment alignment = emitter.getDeviceInfo().getDefaultAlignment();

        // Create a Leap Contoller
        Controller controller = new Controller();

        // Set the position of the new control point
        Vector3 position = new Vector3(0.0f, 0.0f, 0.2f);
        // Set how intense the feeling at the new control point will be
        float intensity = 1.0f;
        // Set the frequency of the control point, which can change the feeling of the sensation
        float frequency = 200.0f;

        // Define the control point
        AmplitudeModulationControlPoint point = new AmplitudeModulationControlPoint (position, intensity, frequency);
        var points = new List<AmplitudeModulationControlPoint> { point };

        // Wait for leap
        if(!controller.IsConnected)
        {
            Console.WriteLine("Waiting for Leap");
            while (!controller.IsConnected)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(".");
            }
            Console.WriteLine("\n");
        }

        Console.WriteLine("hayyyyyyyyyyyyyyy");

        new Stopwatch();

        MIDI dvr = new MIDI();
        
        // Dispose/destroy the emitter
        emitter.Dispose();
        emitter = null;
        dvr.closePort();
        controller.Dispose ();
    }
}
