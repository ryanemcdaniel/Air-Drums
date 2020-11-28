using Leap;

public delegate Vector   Apply_Vectors      (Vector v1      , Vector v2     );
public delegate Vector   Scale_Vectors      (Vector v       , float f       );
public delegate Vector[] Apply_VectorLists  (Vector[] vL1   , Vector[] vL2  );
public delegate Vector[] Scale_VectorLists  (Vector[] vL    , float f       );
public delegate Joints   Apply_Joints       (Joints j1      , Joints j2     );
public delegate Joints   Scale_Joints       (Joints j       , float f       );

public interface IJointsHelper {

    public Vector[] fingerToVectors(Finger f);

    public Joints handToJoints(Hand h);

    public Joints add(Joints j1, Joints j2);

    public Joints sub(Joints j1, Joints j2);

    public Joints div(Joints j1, float f);

    public Vector lowestJoint(Hand h);

    public (Joints min, Joints max) minMax(Joints curMin, Joints curMax, Joints j);

    public Joints square(Joints j);
    
}