using Xunit;
using Moq;
using Leap;
using Global;

public class classify_test {

    [Fact] public void IsGesture_True() {
        var dg = new Data_Generator();
        var hg = new Hand_Generator(dg);
        
        var dat_range = hg.newJoints();

        var exp_bool = dg.newBoolTuple();

        var org_NO_GESTURE_RANGE = GBL.NO_GESTURE_RANGE;
        GBL.NO_GESTURE_RANGE = new Vector{
            x = 2,
            y = 2,
            z = 2
        };

        var mock_vh = new Mock<IVectorHelper>();
        foreach (var v in dat_range.pinky) 
            mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        foreach (var v in dat_range.ring) 
            mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        foreach (var v in dat_range.middle) 
            mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        foreach (var v in dat_range.index) 
            mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        foreach (var v in dat_range.thumb) 
            mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        mock_vh.Setup(m => m.greaterEqual(dat_range.palm, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        
        var c = new Classify(mock_vh.Object);
        var act = c.IsGesture(dat_range);

        foreach (var v in dat_range.pinky) 
            mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        foreach (var v in dat_range.ring) 
            mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        foreach (var v in dat_range.middle) 
            mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        foreach (var v in dat_range.index) 
            mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        foreach (var v in dat_range.thumb) 
            mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        mock_vh.Verify(m => m.greaterEqual(dat_range.palm, GBL.NO_GESTURE_RANGE), Times.Once());
        
        GBL.NO_GESTURE_RANGE = org_NO_GESTURE_RANGE;
        Assert.Equal(act, true);
    
    }

    [Fact] public void IsGesture_False() {
        Assert.True(false);
    }

}