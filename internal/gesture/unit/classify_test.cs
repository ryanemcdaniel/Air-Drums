using Xunit;
using Moq;
using Leap;
using Global;

public class classify_test {

    [Fact] public void IsMovement_True() {
        // var dg = new Data_Generator();
        // var hg = new Hand_Generator(dg);
        
        // var dat_range = hg.newJoints();

        // var exp_bool = dg.newBoolTuple();

        // var mock_vh = new Mock<IVectorHelper>();
        // foreach (var v in dat_range.pinky) 
        //     mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        // foreach (var v in dat_range.ring) 
        //     mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        // foreach (var v in dat_range.middle) 
        //     mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        // foreach (var v in dat_range.index) 
        //     mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        // foreach (var v in dat_range.thumb) 
        //     mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        // mock_vh.Setup(m => m.greaterEqual(dat_range.palm, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        
        // var c = new Classify(mock_vh.Object);
        // var act = c.IsMovement(dat_range);

        // foreach (var v in dat_range.pinky) 
        //     mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        // foreach (var v in dat_range.ring) 
        //     mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        // foreach (var v in dat_range.middle) 
        //     mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        // foreach (var v in dat_range.index) 
        //     mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        // foreach (var v in dat_range.thumb) 
        //     mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        // mock_vh.Verify(m => m.greaterEqual(dat_range.palm, GBL.NO_GESTURE_RANGE), Times.Once());
        
        // Assert.Equal(true, act);
    }

    [Fact] public void IsMovement_False() {
        // var dg = new Data_Generator();
        // var hg = new Hand_Generator(dg);
        
        // var dat_range = hg.newJoints();

        // var exp_bool = (false, false, false);

        // var mock_vh = new Mock<IVectorHelper>();
        // foreach (var v in dat_range.pinky) 
        //     mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        // foreach (var v in dat_range.ring) 
        //     mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        // foreach (var v in dat_range.middle) 
        //     mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        // foreach (var v in dat_range.index) 
        //     mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        // foreach (var v in dat_range.thumb) 
        //     mock_vh.Setup(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        // mock_vh.Setup(m => m.greaterEqual(dat_range.palm, GBL.NO_GESTURE_RANGE)).Returns(exp_bool);
        
        // var c = new Classify(mock_vh.Object);
        // var act = c.IsMovement(dat_range);

        // foreach (var v in dat_range.pinky) 
        //     mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        // foreach (var v in dat_range.ring) 
        //     mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        // foreach (var v in dat_range.middle) 
        //     mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        // foreach (var v in dat_range.index) 
        //     mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        // foreach (var v in dat_range.thumb) 
        //     mock_vh.Verify(m => m.greaterEqual(v, GBL.NO_GESTURE_RANGE), Times.Once());
        // mock_vh.Verify(m => m.greaterEqual(dat_range.palm, GBL.NO_GESTURE_RANGE), Times.Once());
        
        // Assert.Equal(false, act);
    }

    [Fact] public void IsTap_True() {
        Assert.True(false);
    }

}