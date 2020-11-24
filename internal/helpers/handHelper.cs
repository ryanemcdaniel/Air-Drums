using Leap;

public static class Hands {

    public static Vector[] fingerToVectorList(Finger f){
        Vector[] ret = new Vector[f.bones.Length + 1];
        for(int i = 0; i < f.bones.Length; i++) ret[i] = f.bones[i].PrevJoint;
        ret[ret.Length - 1] = f.bones[f.bones.Length - 1].NextJoint;
        return ret;
    }

    public static Vector lowestJoint(Hand h){
        Vector ret = h.Fingers[0].bones[0].PrevJoint;
        foreach (Finger f in h.Fingers) {
            foreach (Vector v in fingerToVectorList(f)){
                if(ret.y > v.y) ret = v;
            }
        }
        if(ret.y > h.PalmPosition.y) ret = h.PalmPosition;
        return ret;
    }

    public static Vector[] fingerTips(Hand h){
        Vector[] ret = new Vector[h.Fingers.Count];
        for(int i = 0; i < h.Fingers.Count; i++){
            ret[i] = h.Fingers[i].bones[3].NextJoint;
        }
        return ret;
    }
}