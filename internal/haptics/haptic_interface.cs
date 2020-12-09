using System.Collections.Generic;
using Leap;
using Ultrahaptics;

public interface IHaptic{
    public List<AmplitudeModulationControlPoint> AquireTarget(Hand h);
    
    public bool updateEmitter(List<AmplitudeModulationControlPoint> positions);
}
