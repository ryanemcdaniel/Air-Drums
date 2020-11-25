using Xunit;
using Moq;
using Leap;

public class handHelper_test {

    [Fact]
    public void FingerToVectorList_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Finger f = hg.newFinger(dg.newVectorList(5));
        
        Vector[] exp = new Vector[5];
        for(int i = 0; i < exp.Length - 1; i++) exp[i] = f.bones[i].PrevJoint;
        exp[exp.Length - 1] = f.bones[exp.Length - 2].NextJoint; 
        
        Mock<VectorHelper> vh_mock = new Mock<VectorHelper>();
        HandHelper hh = new HandHelper(vh_mock.Object);
        Vector[] act = hh.fingerToVectors(f);

        test.vectorListEqual(exp, act);
    }

    [Fact]
    public void LowestJoint_Passes(){
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

        VectorHelper vh = new VectorHelper();
        HandHelper hh = new HandHelper(vh);
        Vector act = hh.lowestJoint(h);

        test.vectorEqual(exp, act);
    }

    [Fact]
    public void FingerTips_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Hand h = hg.newHand();

        Vector[] exp = new Vector[5];
        for(int i = 0; i < h.Fingers.Count; i++){
            exp[i] = h.Fingers[i].bones[3].NextJoint;
        }

        Mock<VectorHelper> vh_mock = new Mock<VectorHelper>();
        HandHelper hh = new HandHelper(vh_mock.Object);
        Vector[] act = hh.fingerTips(h);

        test.vectorListEqual(exp, act);
    }

    [Fact]
    public void handToJoints_Passes() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Hand h = hg.newHand();

        Joints exp = new Joints {
            pinky =  ;
            ring = ;
            middle = ;
            index = ;
            thumb = ;

        };
    
    //When
    
    //Then
    }
}