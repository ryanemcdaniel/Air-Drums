using Leap;

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

    public Joints add(Joints j1, Joints j2) => wholeJoint(vh.add, vh.arrAdd, j1, j2);
    
    public Joints sub(Joints j1, Joints j2)  => wholeJoint(vh.sub, vh.arrSub, j1, j2);

    public Joints div(Joints j, float f) => wholeJoint(vh.div, vh.arrDiv, j, f);

    public Joints pow(Joints j, float f)  => wholeJoint(vh.pow, vh.powList, j, f);

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
        return (curMin, curMax);
    }

    public Joints square(Joints j){
        return new Joints(
            vh.powList(j.pinky  , 2),
            vh.powList(j.ring   , 2),
            vh.powList(j.middle , 2),
            vh.powList(j.index  , 2),
            vh.powList(j.thumb  , 2),
            vh.    pow(j.palm   , 2),
            0
        );
    }

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