using Leap;

public interface IJointsHelper {

    public Vector[] fingerToVectors(Finger f);

    public Joints handToJoints(Hand h);

    public Joints add(Joints j1, Joints j2);

    public Joints sub(Joints j1, Joints j2);

    public Joints div(Joints j1, float f);

    public Vector lowestJoint(Hand h);

    public (Joints min, Joints max) minMax(Joints curMin, Joints curMax, Joints j);

    public Joints pow(Joints j,float f);
    
}