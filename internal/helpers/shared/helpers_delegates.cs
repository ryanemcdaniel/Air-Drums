using Leap;
using System.Collections.Generic;
using System.Linq;

public delegate Joints      Apply_Joints        (Joints j1   , Joints j2   );
public delegate Joints      Scale_Joints        (Joints j    , float f     );
public delegate Vector[]    Apply_VectorLists   (Vector[] vL1, Vector[] vL2);
public delegate Vector[]    Scale_VectorLists   (Vector[] vL , float f     );
public delegate Vector      Apply_Vectors       (Vector v1, Vector v2);
public delegate Vector      Scale_Vectors       (Vector v, float f);
public delegate float       Apply               (float v1, float v2);

public partial class JointsHelper : IJointsHelper {
    
    public Joints wholeJoint(Apply_Vectors toPalm, Apply_VectorLists toFinger, Joints j1, Joints j2){
        return new Joints(
            toFinger(j1.pinky  , j2.pinky  ),
            toFinger(j1.ring   , j2.ring   ),
            toFinger(j1.middle , j2.middle ),
            toFinger(j1.index  , j2.index  ),
            toFinger(j1.thumb  , j2.thumb  ),
            toPalm  (j1.palm   , j2.palm   ),
            0
        );
    }

    public Joints wholeJoint(Scale_Vectors toPalm, Scale_VectorLists toFinger, Joints j, float f){
        return new Joints(
            toFinger(j.pinky  , f),
            toFinger(j.ring   , f),
            toFinger(j.middle , f),
            toFinger(j.index  , f),
            toFinger(j.thumb  , f),
            toPalm  (j.palm   , f),
            0
        );
    }

}

public partial class VectorHelper : IVectorHelper {
    
    public Vector[] wholeVectorList(Apply_Vectors toVectorList, Vector[] vL1, Vector[] vL2){
        var ret = new List<Vector>();
        foreach (var v in vL1.Zip(vL2)) ret.Add(toVectorList(v.First, v.Second));
        return ret.ToArray();
    }

    public Vector[] wholeVectorList(Scale_Vectors toVectorList, Vector[] vL, float f){
        var ret = new List<Vector>();
        foreach (var v in vL) ret.Add(toVectorList(v, f));
        return ret.ToArray();
    }

    public Vector wholeVector(Apply toComponent, Vector v1, Vector v2) => new Vector{
        x = toComponent(v1.x , v2.x),
        y = toComponent(v1.y , v2.y),
        z = toComponent(v1.z , v2.z)
    };

    public Vector wholeVector(Apply toComponent, Vector v, float f) => new Vector{
        x = toComponent(v.x, f),
        y = toComponent(v.y, f),
        z = toComponent(v.z, f)
    };

}