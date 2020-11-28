using Leap;

public delegate float Apply(float v1, float v2);
public delegate Vector Apply_Vectors(Vector v1, Vector v2);
public delegate Vector Scale_Vectors(Vector v, float f);
public delegate Vector[] Apply_VectorLists  (Vector[] vL1, Vector[] vL2);
public delegate Vector[] Scale_VectorLists  (Vector[] vL , float f     );
public delegate Joints   Apply_Joints       (Joints j1   , Joints j2   );
public delegate Joints   Scale_Joints       (Joints j    , float f     );