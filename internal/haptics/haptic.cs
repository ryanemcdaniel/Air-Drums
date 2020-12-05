using Ultrahaptics;
using Leap;
using Global;
using System.Collections.Generic;
using System;

public class Haptic{
    public JointsHelper hh;
    public Haptic(JointsHelper hand){
        hh = hand;
    }
    public AmplitudeModulationControlPoint AquireTarget(Hand h)
    {
        Vector temp = hh.lowestJoint(h);
        return new AmplitudeModulationControlPoint(
            temp.x,
            temp.z,
            -1 * temp.y,
            GBL.UH_INTENSITY,
            GBL.UH_FREQUENCY
        );
    }
        
    public AmplitudeModulationEmitter createEmitter(){
        AmplitudeModulationEmitter emitter = new AmplitudeModulationEmitter();
        return emitter;
    }

    public AmplitudeModulationEmitter updateEmitter(List<AmplitudeModulationControlPoint> positions){
        AmplitudeModulationEmitter emitter = new AmplitudeModulationEmitter();
        if (emitter.update(positions)){
            return emitter;
        }
        else { 
            Console.WriteLine("Emitter update Failure");
            return null;
        }  
    }

    public void stopEmitting(AmplitudeModulationEmitter emitter){
        emitter.stop();
    }

    // public bool isEmitting() {
    //     return true;
    // }

    public void destroyEmitter(AmplitudeModulationEmitter emitter){
        emitter.Dispose();
        emitter = null;
    }
}

