using Xunit;
using Leap;

public class vec_test{

    [Fact]
    public void Data_Vec_Subtract_Passes(){
        Data_Generator dg = new Data_Generator();
        Vector in1 = dg.newVector(); 
        Vector in2 = dg.newVector();
        Vector res = Vec.subtract(in1, in2);
        Assert.Equal(in1.x - in2.x, res.x);
        Assert.Equal(in1.y - in2.y, res.y);
        Assert.Equal(in1.z - in2.z, res.z);
    }

    [Fact]
    public void Data_Vec_Velocity_Passes(){
        Data_Generator dg = new Data_Generator();
        Vector in1 = dg.newVector(); 
        Vector in2 = dg.newVector();
        float frameRate = dg.newFloat(100);
        Vector res = Vec.velocity(in1, in2, frameRate);
        Assert.Equal((in1.x - in2.x) / frameRate, res.x);
        Assert.Equal((in1.y - in2.y) / frameRate, res.y);
        Assert.Equal((in1.z - in2.z) / frameRate, res.z);
    }

    [Fact]
    public void Data_Vec_Greater_Passes(){
        Data_Generator dg = new Data_Generator();
        Vector in1 = dg.newVector();
        Vector in2 = dg.newVector();
        float[] f1 = in1.ToFloatArray();
        float[] f2 = in2.ToFloatArray();
        char[] mode = {'x', 'y', 'z'};
        bool[] res = new bool[3];
        for(int i = 0; i < res.Length; i++) res[i] = Vec.greater(in1, in2, mode[i]);
        for(int i = 0; i < res.Length; i++) Assert.Equal(f1[i] > f2[i], res[i]);
    }
    
}