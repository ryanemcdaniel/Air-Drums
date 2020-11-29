using Leap;
using System.Collections.Generic;

public partial class JointsHelper : IJointsHelper {
    
    public IVectorHelper vh;

    public JointsHelper(IVectorHelper vectorHelper){
        vh = vectorHelper;
    }

    // Basic Joint operations
    public Joints add   (Joints j1, Joints j2)  => wholeJoint(vh.add, vh.addList, j1, j2 );
    public Joints sub   (Joints j1, Joints j2)  => wholeJoint(vh.sub, vh.subList, j1, j2 );
    public Joints div   (Joints j, float f)     => wholeJoint(vh.div, vh.divList, j, f );
    public Joints pow   (Joints j, float f)     => wholeJoint(vh.pow, vh.powList, j, f );

    // Advanced hand operations
    public Vector lowestJoint(Hand h){
        Joints j = handToJoints(h);
        Vector[] ret = new Vector[6];
        ret[0] = vh.lowest(j.pinky);
        ret[1] = vh.lowest(j.ring);
        ret[2] = vh.lowest(j.middle);
        ret[3] = vh.lowest(j.index);
        ret[4] = vh.lowest(j.thumb);
        ret[5] = j.palm;
        return vh.lowest(ret);
    }

    public (Joints min, Joints max) minMax(Joints curMin, Joints curMax, Joints j){
        (curMin.pinky  , curMax.pinky  ) = vh.minMaxList(curMin.pinky  , curMax.pinky  , j.pinky  );
        (curMin.ring   , curMax.ring   ) = vh.minMaxList(curMin.ring   , curMax.ring   , j.ring   );
        (curMin.middle , curMax.middle ) = vh.minMaxList(curMin.middle , curMax.middle , j.middle );
        (curMin.index  , curMax.index  ) = vh.minMaxList(curMin.index  , curMax.index  , j.index  );
        (curMin.thumb  , curMax.thumb  ) = vh.minMaxList(curMin.thumb  , curMax.thumb  , j.thumb  );
        (curMin.palm   , curMax.palm   ) =     vh.minMax(curMin.palm   , curMax.palm   , j.palm   );
        return (curMin, curMax);
    }

    // Joint building functions
    public Vector[] fingerToVectors(Finger f){
        Vector[] ret = new Vector[f.bones.Length + 1];
        for(int i = 0; i < f.bones.Length; i++) ret[i] = f.bones[i].PrevJoint;
        ret[ret.Length - 1] = f.bones[f.bones.Length - 1].NextJoint;
        return ret;
    }

    public Joints handToJoints(Hand h){
        return new Joints(
            fingerToVectors(h.Fingers[0]),
            fingerToVectors(h.Fingers[1]),
            fingerToVectors(h.Fingers[2]),
            fingerToVectors(h.Fingers[3]),
            fingerToVectors(h.Fingers[4]),
            h.PalmPosition,
            0
        );
    }

    public (bool, bool, bool) greaterEqual(Joints j1, Joints j2)
    {
        return (false,false,false);
    }

    public (bool, bool, bool) greaterEqualList(Joints[] j1, Joints[] j2){
        var ret = new List<(bool, bool, bool)>();

        return (false, false,false);
    }

}