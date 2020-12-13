using Xunit;
using Leap;
using System.Collections.Generic;

public class joints_test {

    [Fact] public void ToArray() {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        var dat_j = hg.newJoints();
        var datPinky = dat_j.pinky;
        var datRing = dat_j.ring;
        var datMiddle = dat_j.middle;
        var datIndex = dat_j.index;
        var datThumb = dat_j.thumb;
        var datPalm = dat_j.palm;
        
        Vector[] jVecArr = dat_j.ToArray();
        int k = 0;
        for(int i = 0; i < 5; i++){
            test.Equals(jVecArr[k], datPinky[i]);
            k++;
        }
        for(int i = 0; i < 5; i++){
            test.Equals(jVecArr[k], datRing[i]);
            k++;
        }
        for(int i = 0; i < 5; i++){
            test.Equals(jVecArr[k], datMiddle[i]);
            k++;
        }
        for(int i = 0; i < 5; i++){
            test.Equals(jVecArr[k], datIndex[i]);
            k++;
        }
        for(int i = 0; i < 5; i++){
            test.Equals(jVecArr[k], datThumb[i]);
            k++;
        }
        test.Equals(jVecArr[25], datPalm);
    }
    
    // [Fact] public void ToString() {
    //     Assert.True(false);
    // }
    
}