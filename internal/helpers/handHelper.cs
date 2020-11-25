using Leap;

public class HandHelper {
    
    private VectorHelper vh;

    public HandHelper(VectorHelper vectorHelper){
        vh = vectorHelper;
    }

    public Vector fingertipToVector(Finger f) => f.bones[3].NextJoint;

    public Vector[] fingerToVectors(Finger f){
        Vector[] ret = new Vector[f.bones.Length + 1];
        for(int i = 0; i < f.bones.Length; i++) ret[i] = f.bones[i].PrevJoint;
        ret[ret.Length - 1] = f.bones[f.bones.Length - 1].NextJoint;
        return ret;
    }

    public Vector[] handToVectors(Hand h){
        Vector[] ret = new Vector[25];
        return null;
    }

    public Vector lowestJoint(Hand h){
        Vector ret = h.Fingers[0].bones[0].PrevJoint;
        Vector temp;
        foreach (Finger f in h.Fingers){
            temp = vh.lowest(fingerToVectors(f));
            ret = ret.y > temp.y ? temp : ret;
        }
        return ret.y > h.PalmPosition.y ? h.PalmPosition : ret;
    }

    public Vector[] fingerTips(Hand h){
        Vector[] ret = new Vector[h.Fingers.Count];
        for(int i = 0; i < h.Fingers.Count; i++){
            ret[i] = h.Fingers[i].bones[3].NextJoint;
        }
        return ret;
    }
}