using Xunit;
using Leap;

public class vectorHelper_test{

    [Fact]
    public void Add(){
        Data_Generator dg = new Data_Generator();
        Vector v1 = dg.newVector();
        Vector v2 = dg.newVector();

        Vector exp = new Vector{
            x = v1.x + v2.x,
            y = v1.y + v2.y,
            z = v1.z + v2.z
        };
    }

    [Fact]
    public void Sub(){
        Data_Generator dg = new Data_Generator();
        Vector v1 = dg.newVector(); 
        Vector v2 = dg.newVector();

        Vector exp = new Vector{
            x = v1.x - v2.x,
            y = v1.y - v2.y,
            z = v1.z - v2.z
        };

        VectorHelper v = new VectorHelper();
        Vector act = v.sub(v1, v2);

        test.vectorEqual(exp, act);
    }

    [Fact]
    public void Div(){
        
    }

    [Fact]
    public void ArrAdd(){
        
    }

    [Fact]
    public void ArrSub(){
        
    }

    [Fact]
    public void ArrDiv(){
        
    }

    [Fact]
    public void MinMax(){
        
    }

    [Fact]
    public void Average(){
        Data_Generator dg = new Data_Generator();
        int len = dg.newInt(100);
        Vector[] vL = dg.newVectors(len);

        Vector exp = new Vector(0,0,0);
        for(int i = 0; i < len; i++){
            exp.x += vL[i].x;
            exp.y += vL[i].y;
            exp.z += vL[i].z;
        }
        exp.x /= (float) len;
        exp.y /= (float) len;
        exp.z /= (float) len;

        VectorHelper vh = new VectorHelper();
        Vector act = vh.average(vL);

        test.vectorEqual(exp, act);
    }

    [Fact]
    public void Lowest(){
        Data_Generator dg = new Data_Generator();
        int len = dg.newInt(100);
        Vector[] input = dg.newVectors(len);
        input[0] = new Vector(-1,-1,-1);

        Vector exp = input[0];

        VectorHelper vh = new VectorHelper();
        Vector act = vh.lowest(input);

        test.vectorEqual(exp, act);
    }
}