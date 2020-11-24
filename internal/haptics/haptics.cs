using Ultrahaptics;
using Leap;

public static class Haptic{
    public static AmplitudeModulationControlPoint SetHapticPoint(Vector LeapMotion, float intensity,float frequency)
    {
        Vector3 position = new Vector3(0,0,0);
        //Transforms LeapMotion Coordinate system to UltraHaptic Coordinate system
        position.x = LeapMotion.x;
        position.z = LeapMotion.y;
        position.y = -1 * LeapMotion.z;

        return new AmplitudeModulationControlPoint(position, intensity, frequency);
    }
}