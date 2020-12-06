using Ultrahaptics;
using Leap;
using Global;
using System.Collections.Generic;
using System;

public class Haptic{
    public JointsHelper hh;
    public AmplitudeModulationEmitter ee;
    public Haptic(JointsHelper hand, AmplitudeModulationEmitter emitter){
        hh = hand;
        ee = emitter;
    }
    public List<AmplitudeModulationControlPoint> AquireTarget(Hand h)
    {
        Vector temp = hh.lowestJoint(h);
        AmplitudeModulationControlPoint point = new AmplitudeModulationControlPoint(
            temp.x,
            temp.z,
            -1 * temp.y,
            GBL.UH_INTENSITY,
            GBL.UH_FREQUENCY
        );
        List<AmplitudeModulationControlPoint> Points = new List<AmplitudeModulationControlPoint>();
        Points.Add(point);
        return Points;
    }
    
    public bool updateEmitter(List<AmplitudeModulationControlPoint> positions, AmplitudeModulationEmitter emitter){
        bool IsUpdated = emitter.update(positions);
        if (IsUpdated){
            Console.WriteLine("Emitter successfully updated!");
        }
        else { 
            Console.WriteLine("Emitter failed to update!");
        }  
        return IsUpdated;
    }
}

