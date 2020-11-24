using Xunit;
using Leap;

public class hands_test {

    [Fact]
    public void Data_HandVec_FingerToVectorList_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Finger finger = hg.newFinger(dg.newVectorList(5));

        Vector[] exp = new Vector[5];
        for(int i = 0; i < exp.Length - 1; i++) exp[i] = finger.bones[i].PrevJoint;
        exp[exp.Length - 1] = finger.bones[exp.Length - 2].NextJoint; 

        Vector[] act = Hands.fingerToVectorList(finger);

        test.vectorListEqual(exp, act);
    }

    [Fact]
    public void Data_HandVec_LowestJoint(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Hand h = hg.newHand();

        Vector exp = h.Fingers[0].bones[0].PrevJoint;
        foreach (Finger f in h.Fingers) {
            foreach (Bone b in f.bones) {
                if(exp.y > b.PrevJoint.y) exp = b.PrevJoint;
                if(exp.y > b.NextJoint.y) exp = b.NextJoint;
            }
        }
        if(exp.y > h.PalmPosition.y) exp = h.PalmPosition;

        Vector act = Hands.lowestJoint(h);

        test.vectorEqual(exp, act);
    }

    [Fact]
    public void Data_HandVec_FingerTips(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Hand h = hg.newHand();

        Vector[] exp = new Vector[5];
        for(int i = 0; i < h.Fingers.Count; i++){
            exp[i] = h.Fingers[i].bones[3].NextJoint;
        }

        Vector[] act = Hands.fingerTips(h);

        test.vectorListEqual(exp, act);
    }
}