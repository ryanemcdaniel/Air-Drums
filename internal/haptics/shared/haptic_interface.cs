using Ultrahaptics;
using System.Collections.Generic;

public interface IHaptic{
    public AmplitudeModulationControlPoint AquireTarget(Joints j);
    public bool Emit(List<AmplitudeModulationControlPoint> positions);
}