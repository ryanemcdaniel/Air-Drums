using System.Collections.Generic;
using Leap;
using Ultrahaptics;

public interface IHaptic{
    public AmplitudeModulationControlPoint AquireTarget(Joints j);
    public bool Emit(List<AmplitudeModulationControlPoint> positions);
}