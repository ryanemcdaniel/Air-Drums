using System.Collections.Generic;
using Leap;
using Ultrahaptics;

public interface IHaptic{
    public AmplitudeModulationControlPoint AquireTarget(Joints j);
    public bool UpdateEmitter(List<AmplitudeModulationControlPoint> positions);
}