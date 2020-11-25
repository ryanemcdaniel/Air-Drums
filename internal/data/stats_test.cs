using Xunit;
using Moq;
using System.Collections.Generic;

public class stats_test {
    
    [Fact]
    public void Sum_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        int dat_len = dg.newInt(100);
        List<Joints> dat_jL = hg.newJointsList(dat_len);
        
        Joints exp_sum = hg.newJoints();

        Mock<IJointsHelper> mock_jh = new Mock<IJointsHelper>();
        for (int i = 0; i < dat_len; i++){
            mock_jh.Setup(m => m
            .add(It.IsAny<Joints>(), dat_jL[i]))
            .Returns(exp_sum);
        }

        Stats s = new Stats(mock_jh.Object);
        Joints act_sum = s.sum(dat_jL);

        mock_jh.Verify(m => m.add(It.IsAny<Joints>(), It.IsAny<Joints>()), Times.Exactly(dat_len));
        test.jointsEqual(exp_sum, act_sum);
    }

    [Fact]
    public void Average_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        int dat_len = dg.newInt(100);
        List<Joints> dat_jL = hg.newJointsList(dat_len);

        Joints exp_ave = hg.newJoints();

        Mock<IJointsHelper> mock_jh = new Mock<IJointsHelper>();
        for (int i = 0; i < dat_len; i++){
            mock_jh.Setup(m => m
            .add(It.IsAny<Joints>(), dat_jL[i]))
            .Returns(exp_ave);
        }
        mock_jh.Setup(m => m
        .div(exp_ave, dat_len))
        .Returns(exp_ave);
        
        Stats s = new Stats(mock_jh.Object);
        Joints act_ave = s.ave(dat_jL);
        
        mock_jh.Verify(m => m.add(It.IsAny<Joints>(), It.IsAny<Joints>()), Times.Exactly(dat_len));
        mock_jh.Verify(m => m.div(exp_ave, dat_len), Times.Once());
        test.jointsEqual(exp_ave, act_ave);
    }

    [Fact]
    public void Range_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        int dat_len = dg.newInt(100);
        List<Joints> dat_jL = hg.newJointsList(dat_len);

        Joints exp_ave = hg.newJoints();

        Mock<IJointsHelper> mock_jh = new Mock<IJointsHelper>();
    }

    [Fact]
    public void Velocities_Passes(){
        
    }

}