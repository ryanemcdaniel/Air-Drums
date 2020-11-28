using Xunit;
using Moq;
using Leap;

public class dataManager_test {
    
    [Fact]
    public void Extract_Single(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_f = hg.newFrame();
        dat_f.Hands[0].IsLeft = false;
        dat_f.Hands[1].IsLeft = true;

        var mock_l = new Mock<IQueues>();
        mock_l.Setup(m => m.LoadSample(dat_f.Hands[1], dat_f.CurrentFramesPerSecond));
        var mock_r = new Mock<IQueues>();
        mock_r.Setup(m => m.LoadSample(dat_f.Hands[0], dat_f.CurrentFramesPerSecond));

        var dm = new DataManager(mock_l.Object, mock_r.Object);

        dm.Extract(dat_f);

        mock_l.Verify(m => m.LoadSample(dat_f.Hands[1], dat_f.CurrentFramesPerSecond), Times.Once());
        mock_r.Verify(m => m.LoadSample(dat_f.Hands[0], dat_f.CurrentFramesPerSecond), Times.Once());
    }

    [Fact]
    public void Extract_Multiple(){
        Assert.True(false);
    }
}