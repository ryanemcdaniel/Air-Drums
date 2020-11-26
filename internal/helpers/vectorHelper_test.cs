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
        VectorHelper v = new VectorHelper();
        Vector act = v.add(v1,v2);

        test.vectorEqual(exp,act);
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
        Data_Generator dg = new Data_Generator();
        Vector v1 = dg.newVector();
        float v2 = dg.newFloat(100);
        
        Vector exp = new Vector{
            x = v1.x/v2,
            y = v1.y/v2,
            z = v1.z/v2
        };

        VectorHelper v = new VectorHelper();
        Vector act = v.div(v1, v2);
        test.vectorEqual(exp,act);
    }

    [Fact]
    public void MinMax(){
        Data_Generator dg = new Data_Generator();
        Vector v1 = dg.newVector();
        Vector v2 = new Vector{
            x = v1.x + dg.newFloat(100),
            y = v1.y - dg.newFloat(100),
            z = v1.z - dg.newFloat(100)
        };

        Vector expMin = new Vector{
            x = v1.x,
            y = v2.y,
            z = v2.z
        };

        Vector expMax = new Vector{
            x = v2.x,
            y = v1.y,
            z = v1.z
        };
        VectorHelper v = new VectorHelper();
        (Vector actMin,Vector actMax) = v.minMax(v1,v2);
        test.vectorEqual(expMax,actMax);
        test.vectorEqual(expMin,actMin);
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
    public void arrAdd(){
        Data_Generator dg = new Data_Generator();
        int length = dg.newInt(100);
        Vector[] v1 = dg.newVectors(length);
        Vector[] v2 = dg.newVectors(length);
        Vector[] exp = dg.newZeroVectors(length);

        for(int i =0; i < length; i++)
        {
            exp[i].x = v1[i].x + v2[i].x;
            exp[i].y = v1[i].y + v2[i].y;
            exp[i].z = v1[i].z + v2[i].z;
        }
        VectorHelper v = new VectorHelper();
        Vector[] act = v.arrAdd(v1,v2);
        test.vectorsEqual(exp,act);
    }

    [Fact]
    public void arrSub(){
        Data_Generator dg = new Data_Generator();
        int length = dg.newInt(100);
        Vector[] v1 = dg.newVectors(length);
        Vector[] v2 = dg.newVectors(length);
        Vector[] exp = dg.newZeroVectors(length);

        for(int i =0; i < length; i++)
        {
            exp[i].x = v1[i].x - v2[i].x;
            exp[i].y = v1[i].y - v2[i].y;
            exp[i].z = v1[i].z - v2[i].z;
        }
        VectorHelper v = new VectorHelper();
        Vector[] act = v.arrSub(v1,v2);
        test.vectorsEqual(exp,act);
    }

    
    [Fact]
    public void arrDiv(){
        Data_Generator dg = new Data_Generator();
        int length = dg.newInt(100);
        Vector[] v1 = dg.newVectors(length);
        float v2 = dg.newFloat(100);
        Vector[] exp = dg.newZeroVectors(length);

        for(int i =0; i < length; i++)
        {
            exp[i].x = v1[i].x / v2;
            exp[i].y = v1[i].y / v2;
            exp[i].z = v1[i].z / v2;
        }
        VectorHelper v = new VectorHelper();
        Vector[] act = v.arrDiv(v1,v2);
        test.vectorsEqual(exp,act);
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