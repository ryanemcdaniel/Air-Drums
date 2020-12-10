using Ultrahaptics;
using Leap;
using Global;
using System.Collections.Generic;
using System;

public class Haptic : IHaptic {
    public JointsHelper jh;
    public AmplitudeModulationEmitter ee;
    public Haptic(JointsHelper hand, AmplitudeModulationEmitter emitter){
        jh = hand;
        ee = emitter;
    }
    public AmplitudeModulationControlPoint AquireTarget(Joints j) {
        AmplitudeModulationControlPoint point = new AmplitudeModulationControlPoint(
            j.TipsNoThumb()[2].x,
            j.TipsNoThumb()[2].z * -1,
            j.TipsNoThumb()[2].y,
            GBL.UH_INTENSITY,
            GBL.UH_FREQUENCY
        );
        return point;
    }
    
    public bool UpdateEmitter(List<AmplitudeModulationControlPoint> positions) {
        bool IsUpdated = ee.update(positions);
        if (IsUpdated){
            Console.WriteLine("Emitter successfully updated!");
        }
        else { 
            Console.WriteLine("Emitter failed to update!");
        }  
        return IsUpdated;
    }
}

