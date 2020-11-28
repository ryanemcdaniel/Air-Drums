using Xunit;

public class classify_test {

    [Fact] public void IsGesture_True() {
        var dg = new Data_Generator();
        var hg = new Hand_Generator(dg);
        
        var dat_range = hg.newJoints();

        var exp = dat_range;

        


    }

    [Fact] public void IsGesture_False() {
        Assert.True(false);
    }

}