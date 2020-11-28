using Xunit;

using Moq;
using System.Collections.Generic;
using System.Linq;

public class stats_test {
    
    [Fact]
    public void Sum(){
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
    public void Average(){
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
        Joints act_ave = s.average(dat_jL);
        
        mock_jh.Verify(m => m.add(It.IsAny<Joints>(), It.IsAny<Joints>()), Times.Exactly(dat_len));
        mock_jh.Verify(m => m.div(exp_ave, dat_len), Times.Once());
        test.jointsEqual(exp_ave, act_ave);
    }

    [Fact]
    public void Range(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        int dat_len = dg.newInt(100);
        List<Joints> dat_jL = hg.newJointsList(dat_len);

        Joints exp_range = hg.newJoints();
        Joints exp_min = hg.newJoints();
        Joints exp_max = hg.newJoints();

        Mock<IJointsHelper> mock_jh = new Mock<IJointsHelper>();
        foreach (var j in dat_jL) {
            mock_jh.Setup(m => m.minMax(It.IsAny<Joints>(), It.IsAny<Joints>(), j)).Returns((exp_min, exp_max));
        }
        mock_jh.Setup(m => m.sub(exp_max, exp_min)).Returns(exp_range);

        Stats s = new Stats(mock_jh.Object);
        Joints act_range = s.range(dat_jL);

        foreach (var j in dat_jL) {
            mock_jh.Verify(m => m.minMax(It.IsAny<Joints>(), It.IsAny<Joints>(), j), Times.Once());
        }
        mock_jh.Verify(m => m.sub(exp_max, exp_min), Times.Once());
        test.jointsEqual(exp_range, act_range);
    }

    [Fact] public void Variance(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        int dat_len = dg.newInt(100);
        List<Joints> dat_jL = hg.newJointsList(dat_len);
        var mock_vh = new Mock<IVectorHelper>();
        Joints exp_sum = hg.newJoints();
        Joints exp_avg = hg.newJoints();
        Joints exp = hg.newJoints();
        Joints exp_error = hg.newJoints();
        Joints exp_sq_error = hg.newJoints();
        Joints exp_sum_sq_error = hg.newJoints();
        Joints exp_Variance = hg.newJoints();
        
        Mock<IJointsHelper> mock_jh = new Mock<IJointsHelper>();
        foreach (var j in dat_jL){
            mock_jh.Setup(m =>m.add(It.IsAny<Joints>(),j)).Returns(exp_sum);
        }
        mock_jh.Setup(m =>m.div(exp_sum,dat_len)).Returns(exp_avg);

        foreach (var j in dat_jL){
            mock_jh.Setup(m =>m.sub(j,exp_avg)).Returns(exp_error);
            mock_jh.Setup(m =>m.pow(exp_error,2)).Returns(exp_sq_error);
            mock_jh.Setup(m =>m.add(It.IsAny<Joints>(),exp_sq_error)).Returns(exp_sum_sq_error);
        }
        mock_jh.Setup(m=>m.div(exp_sum_sq_error,dat_len - 1)).Returns(exp_Variance);

        Stats s = new Stats(mock_jh.Object);
        var act_Variance = s.variance(dat_jL);

        foreach (var j in dat_jL){
            mock_jh.Verify(m =>m.add(It.IsAny<Joints>(),j),Times.Once());
        }
        mock_jh.Verify(m =>m.div(exp_sum,dat_len),Times.Once());

        foreach (var j in dat_jL){
            mock_jh.Verify(m =>m.sub(j,exp_avg),Times.Once());
            mock_jh.Verify(m =>m.pow(exp_error,2),Times.Exactly(dat_len));
            mock_jh.Verify(m =>m.add(It.IsAny<Joints>(),exp_sq_error),Times.Exactly(dat_len));
        }

        test.jointsEqual(exp_Variance,act_Variance);


    }
}