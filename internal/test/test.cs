using Xunit;
using Leap;

public static class test {
    
    public static void vectorEqual(Vector v1, Vector v2){
        Assert.Equal(v1.x, v2.x);
        Assert.Equal(v1.y, v2.y);
        Assert.Equal(v1.z, v2.z);
    }

    public static void vectorListEqual(Vector[] vL1, Vector[] vL2){
        Assert.Equal(vL1.Length, vL2.Length);
        for(int i = 0; i < vL1.Length; i++){
            vectorEqual(vL1[i], vL2[i]);
        }
    }

}