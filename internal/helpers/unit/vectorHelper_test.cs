using Xunit;
using Leap;
using System;
using System.Linq;
using System.Collections.Generic;

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

    [Fact] public void Sub() {
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

    [Fact] public void Div() {
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

    [Fact] public void AddList() {
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

    [Fact] public void SubList() {
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
    
    [Fact] public void DivList() {
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

        [Fact] public void MinMax() {
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

        [Fact] public void MinMaxList() {
        var dg = new Data_Generator();
        //var dat_i = 0;
        var dat_len = dg.newInt(100);

        var dat_vA = dg.newVectors(dat_len);
        var dat_min = dg.newMinVectors(dat_len);
        var dat_max = dg.newZeroVectors(dat_len);

        (Vector[] min, Vector[] max) exp = (new Vector[dat_len], new Vector[dat_len]);
        exp.min = dat_min; 
        exp.max = dat_vA;

        var vh = new VectorHelper();
        (Vector[] min, Vector[] max) act = vh.minMaxList(dat_min, dat_max, dat_vA);

        test.vectorsEqual(exp.min, act.min);
        test.vectorsEqual(exp.max, act.max);
    }

    [Fact] public void Average() {
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

    [Fact] public void Lowest() {
        Data_Generator dg = new Data_Generator();
        int len = dg.newInt(100);
        Vector[] input = dg.newVectors(len);
        input[0] = new Vector(-1,-1,-1);

        Vector exp = input[0];

        VectorHelper vh = new VectorHelper();
        Vector act = vh.lowest(input);

        test.vectorEqual(exp, act);
    }

    [Fact] public void GreaterEqual() {
        Data_Generator dg = new Data_Generator();
        Vector v1 = dg.newVector();
        Vector v2 = dg.newVector();
        (bool exp_x, bool exp_y, bool exp_z) = dg.newBoolTuple();
        if(v1.x >= v2.x){
            exp_x = true;
        }
        if(v1.y >= v2.y){
            exp_y = true;
        }
        if(v1.z >= v2.z){
            exp_z = true;
        }
        VectorHelper v = new VectorHelper();
        (bool act_x, bool act_y, bool act_z) = v.greaterEqual(v1,v2);
        test.Equals(exp_x,act_x);
        test.Equals(exp_y,act_y);
        test.Equals(exp_z,act_z);
    }

    [Fact] public void IdentQuadrant_Passes()
        {
            Vector Quad1 = new Vector(1,0,-1);
            Vector Quad2 = new Vector(-1,0,-1);
            Vector Quad3 = new Vector(-1,0,1);
            Vector Quad4 = new Vector(1,0,1);

            int expQuad1 =0;
            int expQuad2 =0;
            int expQuad3 =0;
            int expQuad4 =0;

            
            if(Quad1.x > 0 && Quad1.z < 0)
            {
                expQuad1 = 1;
            }
            if(Quad2.x < 0 && Quad2.z < 0)
            {
                expQuad2 = 2;
            }
            if(Quad3.x < 0 && Quad3.z > 0)
            {
                expQuad3 = 3;
            }
            if(Quad4.x > 0 && Quad4.z > 0)
            {
                expQuad4 = 4;
            }
            
            VectorHelper v= new VectorHelper();
            int actQuad1 = v.IdentQuadrant(Quad1);
            int actQuad2 = v.IdentQuadrant(Quad2);
            int actQuad3 = v.IdentQuadrant(Quad3);
            int actQuad4 = v.IdentQuadrant(Quad4);

            test.Equals(actQuad1,expQuad1);
            test.Equals(actQuad2,expQuad2);
            test.Equals(actQuad3,expQuad3);
            test.Equals(actQuad4,expQuad4);
        }
    

    [Fact] public void greaterEqualListOneToOne() {
        Data_Generator dg = new Data_Generator();
        int length = dg.newInt(100);
        Vector[] v1 = dg.newVectors(length);
        Vector[] v2 = dg.newVectors(length);
        
        var exp_tupleList = new (bool exp_x, bool exp_y, bool exp_z)[length];
        exp_tupleList = dg.newBoolTupleList(length);
        for(int i = 0; i< length;i++)
        {
            if(v1[i].x >= v2[i].x){
                exp_tupleList[i].exp_x = true;
            }
            if(v1[i].y >= v2[i].y){
                exp_tupleList[i].exp_y = true;
            }
            if(v1[i].z >= v2[i].z){
                exp_tupleList[i].exp_z = true;
            }
        }
        VectorHelper v = new VectorHelper();
        var act_tupleList = new (bool act_x, bool act_y, bool act_z)[length];
        act_tupleList = v.greaterEqualListOneToOne(v1,v2);
        for(int i = 0; i<length; i++){
            test.Equals(act_tupleList[i],exp_tupleList[i]);
        }
    }
    [Fact] public void greaterEqualListOnetoMany() {
        Data_Generator dg = new Data_Generator();
        int length = dg.newInt(100);
        Vector[] v1 = dg.newVectors(length);
        Vector v2 = dg.newVector();
        
        var exp_tupleList = new (bool exp_x, bool exp_y, bool exp_z)[length];
        exp_tupleList = dg.newBoolTupleList(length);
        for(int i = 0; i< length;i++)
        {
            if(v1[i].x >= v2.x){
                exp_tupleList[i].exp_x = true;
            }
            if(v1[i].y >= v2.y){
                exp_tupleList[i].exp_y = true;
            }
            if(v1[i].z >= v2.z){
                exp_tupleList[i].exp_z = true;
            }
        }
        VectorHelper v = new VectorHelper();
        var act_tupleList = new (bool act_x, bool act_y, bool act_z)[length];
        act_tupleList = v.greaterEqualListOnetoMany(v1,v2);
        for(int i = 0; i<length; i++){
            test.Equals(act_tupleList[i],exp_tupleList[i]);
        }
    }
}