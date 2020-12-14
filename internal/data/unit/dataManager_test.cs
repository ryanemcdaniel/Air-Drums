using Xunit;
using Moq;
using Leap;
using System.Collections.Generic;

public class dataManager_test {
    
    [Fact] public void Extract_Single(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_f = hg.newFrame();
        dat_f.Hands[0].IsLeft = false;
        dat_f.Hands[1].IsLeft = true;

        var mock_l = new Mock<IQueues>();
        mock_l.Setup(m => m.LoadSample(dat_f.Hands[1], dat_f.CurrentFramesPerSecond));

        var dm = new DataManager(mock_l.Object, true);

        dm.Extract(dat_f);

        mock_l.Verify(m => m.LoadSample(dat_f.Hands[1], dat_f.CurrentFramesPerSecond), Times.Once());
    }

    [Fact] public void Extract_Multiple(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_f1 = hg.newFrame();
        var dat_f2 = hg.newFrame();
        dat_f1.Hands[0].IsLeft = false;
        dat_f1.Hands[1].IsLeft = true;
        dat_f2.Hands[0].IsLeft = false;
        dat_f2.Hands[1].IsLeft = true;

        var mock_l = new Mock<IQueues>();
        var mock_2 = new Mock<IQueues>();
        mock_l.Setup(m => m.LoadSample(dat_f1.Hands[1], dat_f1.CurrentFramesPerSecond));
        mock_2.Setup(m => m.LoadSample(dat_f2.Hands[1], dat_f2.CurrentFramesPerSecond));

        var dm1 = new DataManager(mock_l.Object, true);
        var dm2 = new DataManager(mock_2.Object, true);
        dm1.Extract(dat_f1);
        dm2.Extract(dat_f2);

        mock_l.Verify(m => m.LoadSample(dat_f1.Hands[1], dat_f1.CurrentFramesPerSecond), Times.Once());
        mock_2.Verify(m => m.LoadSample(dat_f2.Hands[1], dat_f2.CurrentFramesPerSecond), Times.Once());
    }

    [Fact] public void Extract_ClearsQueues() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_f = hg.newFrame();
        dat_f.Hands[0].IsLeft = false;
        dat_f.Hands[1].IsLeft = true;

        var mock_l = new Mock<IQueues>();
        mock_l.Setup(m => m.LoadSample(dat_f.Hands[1], dat_f.CurrentFramesPerSecond));

        var dm = new DataManager(mock_l.Object, true);
        dm.Extract(dat_f);

        var dataCount = dm.GetData();
        (List<Joints> position, List<Joints> velocity) exp;
        exp.position = null;
        exp.velocity = null;

        test.Equals(dataCount, exp);
    }
}