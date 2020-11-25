using Xunit;
using Moq;
using Leap;
using System.Collections.Generic;

public class jointsHelper_test {

    [Fact]
    public void FingerToVectorList_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Finger inp_finger = hg.newFinger(dg.newVectors(5));
        
        Vector[] exp_vL = new Vector[]{
            inp_finger.bones[0].PrevJoint,
            inp_finger.bones[1].PrevJoint,
            inp_finger.bones[2].PrevJoint,
            inp_finger.bones[3].PrevJoint,
            inp_finger.bones[3].NextJoint,
        };

        VectorHelper vh = new VectorHelper();
        JointsHelper jh = new JointsHelper(vh);
        Vector[] act_vL = jh.fingerToVectors(inp_finger);

        test.vectorsEqual(exp_vL, act_vL);
    }

    [Fact]
    public void HandToJoints_Passes()
    {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        List<Vector[]> dat_vL = new List<Vector[]>(){
            dg.newVectors(5),
            dg.newVectors(5),
            dg.newVectors(5),
            dg.newVectors(5),
            dg.newVectors(5),
        };
        List<Finger> dat_fL = hg.newFingerList(dat_vL);
        Hand dat_hand = hg.newHand(dat_fL);

        Joints exp_joints = new Joints{
            pinky   = dat_vL[0],
            ring    = dat_vL[1],
            middle  = dat_vL[2],
            index   = dat_vL[3],
            thumb   = dat_vL[4],
            palm    = dat_hand.PalmPosition
        };

        VectorHelper vh = new VectorHelper();
        JointsHelper jh = new JointsHelper(vh);
        Joints act_joints = jh.handToJoints(dat_hand);

        test.jointsEqual(exp_joints, act_joints);
    }

    [Fact]
    public void LowestJoint_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Hand dat_hand = hg.newHand(hg.newFingerList());

        Vector exp_joint = new Vector(-1, -1, -1);
        dat_hand.Fingers[4].bones[3].NextJoint = exp_joint;

        VectorHelper vh = new VectorHelper();
        JointsHelper jh = new JointsHelper(vh);
        Vector act_joint = jh.min(dat_hand);
    }
}