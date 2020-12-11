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

    public bool Emit(List<AmplitudeModulationControlPoint> positions) {
        bool IsUpdated = ee.update(positions);
        return IsUpdated;
    }

    public AmplitudeModulationControlPoint AquireTarget(Joints j) => new AmplitudeModulationControlPoint(
        j.palm.x,
        j.palm.z * -1,
        j.palm.y,
        GBL.UH_INTENSITY,
        GBL.UH_FREQUENCY
    );
}

