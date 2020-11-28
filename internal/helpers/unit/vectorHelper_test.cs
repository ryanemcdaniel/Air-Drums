using Xunit;
using Leap;
using System;
using System.Linq;

public class vectorHelper_test{

    [Fact] public void Pow(){
        Data_Generator dg = new Data_Generator();
        Vector v1 = dg.newVector();
        float f = dg.newFloat(100);

        Vector exp = new Vector{
            x =(float) Math.Pow(v1.x, f),
            y = (float) Math.Pow(v1.y,f),
            z = (float) Math.Pow(v1.z, f)
        };

        VectorHelper v = new VectorHelper();
        Vector act = v.pow(v1,f);
        test.vectorEqual(act,exp);
    }

    [Fact] public void PowList(){
        Data_Generator dg = new Data_Generator();
        int length = dg.newInt(100);
        float f = dg.newFloat(100);
        Vector[] v1 = dg.newVectors(length);
        Vector[] exp = dg.newZeroVectors(length);
        for(int i =0; i<length; i++)
        {
            exp[i].x = (float) Math.Pow(v1[i].x,f);
            exp[i].y = (float) Math.Pow(v1[i].y,f);
            exp[i].z = (float) Math.Pow(v1[i].z,f);
        }
        VectorHelper v = new VectorHelper();
        Vector[] act = v.powList(v1,f);
        test.vectorsEqual(act,exp);
    }

    [Fact] public void Add() {
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
    public void Sub() {
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
    public void Div() {
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
        (Vector min, Vector max, Vector v) dat;
        dat.v = dg.newVector();
        dat.min = new Vector(float.MinValue, float.MinValue, float.MinValue);
        dat.max = dg.newZeroVector();

        (Vector min, Vector max) exp;
        exp.min = dat.min;
        exp.max = dat.v;

        var v = new VectorHelper();
        var act = v.minMax(dat.min, dat.max, dat.v);
        test.vectorEqual(exp.min, act.min);
        test.vectorEqual(exp.max, act.max);
    }

    [Fact]
    public void ArrAdd(){
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
        Vector[] act = v.addList(v1,v2);
        test.vectorsEqual(exp,act);
    }

    [Fact]
    public void ArrSub(){
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
        Vector[] act = v.subList(v1,v2);
        test.vectorsEqual(exp,act);
    }
    
    [Fact]
    public void ArrDiv(){
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
        Vector[] act = v.divList(v1,v2);
        test.vectorsEqual(exp,act);
    }

    [Fact]
    public void ArrMinMax(){
        var dg = new Data_Generator();
        var dat_i = 0;
        var dat_len = dg.newInt(100);
        var dat_vA = dg.newVectors(dat_len);
        var dat_min = new Vector[dat_len];
        var dat_max = dg.newZeroVectors(dat_len);
        
        foreach (var v in dat_vA) {
            dat_min[dat_i++] = new Vector{
                x = dat_i % 2 == 0 ? v.x - dg.newFloat(100) : v.x + dg.newFloat(100),
                y = dat_i % 2 == 0 ? v.y - dg.newFloat(100) : v.y + dg.newFloat(100),
                z = dat_i % 2 == 0 ? v.z - dg.newFloat(100) : v.z + dg.newFloat(100)
            };
        }

        (Vector[] min, Vector[] max) exp = (new Vector[dat_len], new Vector[dat_len]);
        foreach (var v in dat_vA.Zip(dat_min).Reverse()){
            (exp.min[--dat_len], exp.max[dat_len]) = dat_len % 2 == 0 ? (v.Second, v.First) : (v.First, v.Second);
        }

        var vh = new VectorHelper();
        var act = vh.minMaxList(dat_min, dat_max, dat_vA);

        test.vectorsEqual(exp.min, act.min);
        test.vectorsEqual(exp.max, act.max);
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