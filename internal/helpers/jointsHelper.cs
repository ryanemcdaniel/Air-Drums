using System.Collections.Generic;
using Leap;

public class JointsHelper {
    
    private VectorHelper vh;

    public JointsHelper(VectorHelper vectorHelper){
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
            h.PalmPosition
        );
    }

    public Vector lowestJoint(Hand h){
        Joints j = handToJoints(h);
        Vector[] ret = new Vector[6];
        ret[0] = vh.min(j.pinky);
        ret[1] = vh.min(j.ring);
        ret[2] = vh.min(j.middle);
        ret[3] = vh.min(j.index);
        ret[4] = vh.min(j.thumb);
        ret[5] = j.palm;
        return vh.min(ret);
    }
}