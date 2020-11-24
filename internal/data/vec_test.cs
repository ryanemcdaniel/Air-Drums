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
    public void Data_Vec_Average_Passes(){
        Data_Generator dg = new Data_Generator();
        int len = dg.newInt(100);
        Vector[] input = dg.newVectorList(len);
        Vector act = Vec.average(input);
        Vector exp = new Vector(0,0,0);
        for(int i = 0; i < len; i++){
            exp.x += input[i].x;
            exp.y += input[i].y;
            exp.z += input[i].z;
        }
        exp.x /= (float) len;
        exp.y /= (float) len;
        exp.z /= (float) len;
        Assert.Equal(exp.x, act.x);
        Assert.Equal(exp.y, act.y);
        Assert.Equal(exp.z, act.z);
    }

    [Fact]
    public void Data_Vec_Lowest_Passes(){
        Data_Generator dg = new Data_Generator();
        int len = dg.newInt(100);
        Vector[] input = dg.newVectorList(len);
        
        Vector exp = input[0];
        foreach (Vector v in input) {
            if(v.y < exp.y){
                exp.x = v.x;
                exp.y = v.y;
                exp.z = v.z;
            }
        }

        Vector res = Vec.lowest(input);
        Assert.Equal(exp.x, res.x);
        Assert.Equal(exp.y, res.y);
        Assert.Equal(exp.z, res.z);
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