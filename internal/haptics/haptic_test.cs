using Ultrahaptics;
using Leap;
using Xunit;
using Global;
using System.Collections.Generic;
public class haptic_test{
    
    [Fact] public void Emit () {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        
        VectorHelper vh = new VectorHelper();
        JointsHelper jh = new JointsHelper(vh);
        AmplitudeModulationEmitter mock_emitter = new AmplitudeModulationEmitter("MockDevice:U5;logfile=log.txt");

        var j = hg.newJoints();
        bool exp = false;
        bool act = false;
        var haptic = new Haptic(jh, mock_emitter);
        var point = haptic.AquireTarget(j);
        var points = new List<AmplitudeModulationControlPoint>();
        points.Add(point);
        exp = mock_emitter.update(points);
        act = haptic.Emit(points);

        Assert.Equal(exp,act);
    }

    [Fact] public void AquireTarget() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Joints inp_joint = hg.newJoints();
        float org_UH_INTENSITY = GBL.UH_INTENSITY;
        float org_UH_FREQUENCY = GBL.UH_FREQUENCY;

        float exp_UH_INTENSITY = dg.newFloat(100);
        float exp_UH_FREQUENCY = dg.newFloat(200);
        AmplitudeModulationControlPoint exp = new AmplitudeModulationControlPoint(
            inp_joint.TipsNoThumb()[2].x,
            inp_joint.TipsNoThumb()[2].z * -1,
            inp_joint.TipsNoThumb()[2].y,
            exp_UH_INTENSITY,
            exp_UH_FREQUENCY
        );      
        Haptic h = new Haptic(new JointsHelper(new VectorHelper()),new AmplitudeModulationEmitter());
        var act = h.AquireTarget(inp_joint);
        GBL.UH_INTENSITY = org_UH_INTENSITY;
        GBL.UH_FREQUENCY = org_UH_FREQUENCY;
        Assert.Equal(exp.getPosition().x,act.getPosition().x);
        Assert.Equal(exp.getPosition().y,act.getPosition().y);
        Assert.Equal(exp.getPosition().z,act.getPosition().z);
    }
}