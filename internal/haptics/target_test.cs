using Ultrahaptics;
using Leap;
using Xunit;
using Global;
using System.Collections.Generic;
public class Target_Test{
    
    [Fact]
    public void AquireTarget_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var inp_fingerList = hg.newFingerList();
        Hand inp_hand = hg.newHand(inp_fingerList);
        float org_UH_INTENSITY = GBL.UH_INTENSITY;
        float org_UH_FREQUENCY = GBL.UH_FREQUENCY;

        float exp_UH_INTENSITY = dg.newFloat(100);
        float exp_UH_FREQUENCY = dg.newFloat(200);
        AmplitudeModulationControlPoint exp = new AmplitudeModulationControlPoint(
            -1,
             1,
            -1,
            exp_UH_INTENSITY,
            exp_UH_FREQUENCY
        );
        inp_hand.Fingers[0].bones[0].PrevJoint = new Vector(
            -1,
            -1,
            1
        );
        
        Haptic h = new Haptic(new JointsHelper(new VectorHelper()));
        List<AmplitudeModulationControlPoint> act = h.AquireTarget(inp_hand);
        GBL.UH_INTENSITY = org_UH_INTENSITY;
        GBL.UH_FREQUENCY = org_UH_FREQUENCY;

        Assert.Equal(exp.getPosition().x,act[0].getPosition().x);
        Assert.Equal(exp.getPosition().y,act[0].getPosition().z);
        Assert.Equal(-1 * exp.getPosition().z,act[0].getPosition().y);
    }

    [Fact]
    public void updateEmitter_Passes()
    {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        VectorHelper vh = new VectorHelper();
        JointsHelper jh = new JointsHelper(vh);
        AmplitudeModulationEmitter mock_emitter = new AmplitudeModulationEmitter("MockDevice:U5;logfile=log.txt");

        var Fingers = hg.newFingerList();
        var Hand = hg.newHand(Fingers);
        bool exp = false;
        bool act = false;
        var haptic = new Haptic(jh);
        var points = haptic.AquireTarget(Hand);
        exp = mock_emitter.update(points);
        act = haptic.updateEmitter(points,mock_emitter);

        Assert.Equal(exp,act);
    }
}