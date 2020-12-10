using Xunit;
using Moq;
using Leap;
using Global;

public class queues_test {

    [Fact] public void Load_Once() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_hnd = hg.newHand(hg.newFingerList());
        var dat_fps = dg.newFloat(100);

        var exp_hnd = dat_hnd;
        var exp_pos = hg.newJoints();

        var mock_jh = new Mock<IJointsHelper>();
        mock_jh.Setup(m => m.handToJoints(dat_hnd)).Returns(exp_pos);

        var org_N_SAMPLES = GBL.N_SAMPLES;
        GBL.N_SAMPLES = dg.newInt(100);
        var q = new Queues(mock_jh.Object);
        q.LoadSample(dat_hnd, dat_fps);
        var act_hnd = q.GetSamples();
        var act_pos = q.GetPositions();
        var act_vel = q.GetVelocities();
        GBL.N_SAMPLES = org_N_SAMPLES;

        mock_jh.Verify(m => m.handToJoints(dat_hnd), Times.Once());
        mock_jh.Verify(m => m.sub(It.IsAny<Joints>(), It.IsAny<Joints>()), Times.Never());
        mock_jh.Verify(m => m.div(It.IsAny<Joints>(), It.IsAny<float>()), Times.Never());
        test.handEqual(exp_hnd, act_hnd[0]);
        test.jointsEqual(exp_pos, act_pos[0]);
        Assert.Single<Hand>(act_hnd);
        Assert.Single<Joints>(act_pos);
        Assert.Single<Joints>(act_vel);
    }

    [Fact] public void Load_Multiple() {
        Assert.True(false);
    }

    [Fact] public void Clear() {
        Assert.True(false);
    }

}