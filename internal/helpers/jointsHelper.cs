using System.Reflection;
using System.Collections.Generic;
using Leap;

public interface IJointsHelper {
    public Vector[] fingerToVectors(Finger f);
    public Joints handToJoints(Hand h);
    public Joints add(Joints j1, Joints j2);
    public Joints sub(Joints j1, Joints j2);
    public Joints div(Joints j1, int i);
    public Joints div(Joints j1, float f);
    public Vector lowestJoint(Hand h);
    public (Joints min, Joints max) minMax(Joints curMin, Joints curMax, Joints j);
}

public class JointsHelper : IJointsHelper {
    
    public IVectorHelper vh;

    public JointsHelper(IVectorHelper vectorHelper){
        vh = vectorHelper;
    }

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

    public Joints add(Joints j1, Joints j2){
        return new Joints(
            vh.arrAdd(j1.pinky, j2.pinky),
            vh.arrAdd(j1.ring, j2.ring),
            vh.arrAdd(j1.middle, j2.middle),
            vh.arrAdd(j1.index, j2.index),
            vh.arrAdd(j1.thumb, j2.thumb),
            vh.add(j1.palm, j2.palm),
            0
        );
    }
    
    public Joints sub(Joints j1, Joints j2){
        return new Joints(
            vh.arrSub(j1.pinky,     j2.pinky),
            vh.arrSub(j1.ring,      j2.ring),
            vh.arrSub(j1.middle,    j2.middle),
            vh.arrSub(j1.index,     j2.index),
            vh.arrSub(j1.thumb,     j2.thumb),
            vh.sub(j1.palm,         j2.palm),
            0
        );
    }

    public Joints div(Joints j1, int i){
        return new Joints(
            vh.arrDiv(j1.pinky, i),
            vh.arrDiv(j1.ring,  i),
            vh.arrDiv(j1.middle,i),
            vh.arrDiv(j1.index, i),
            vh.arrDiv(j1.thumb, i),
            vh.div(j1.palm,     i),
            0
        );
    }

    public Joints div(Joints j1, float i){
        return new Joints(
            vh.arrDiv(j1.pinky, i),
            vh.arrDiv(j1.ring,  i),
            vh.arrDiv(j1.middle,i),
            vh.arrDiv(j1.index, i),
            vh.arrDiv(j1.thumb, i),
            vh.div(j1.palm,     i),
            0
        );
    }

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
        (curMin.pinky  , curMax.pinky  ) = vh.arrMinMax(curMin.pinky  , curMax.pinky  , j.pinky  );
        (curMin.ring   , curMax.ring   ) = vh.arrMinMax(curMin.ring   , curMax.ring   , j.ring   );
        (curMin.middle , curMax.middle ) = vh.arrMinMax(curMin.middle , curMax.middle , j.middle );
        (curMin.index  , curMax.index  ) = vh.arrMinMax(curMin.index  , curMax.index  , j.index  );
        (curMin.thumb  , curMax.thumb  ) = vh.arrMinMax(curMin.thumb  , curMax.thumb  , j.thumb  );
        (curMin.palm   , curMax.palm   ) =    vh.minMax(curMin.palm   , curMax.palm   , j.palm   );
        return (null, null);
    }
}