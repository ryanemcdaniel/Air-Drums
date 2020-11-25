using Ultrahaptics;
using Leap;
using Global;

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
}

