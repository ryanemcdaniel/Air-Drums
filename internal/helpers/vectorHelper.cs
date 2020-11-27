using System;
using Leap;
using System.Collections.Generic;

public interface IVectorHelper{
    public (bool x, bool y, bool z) greaterEqual(Vector v1, Vector v2);
    public Vector add(Vector v1, Vector v2);
    public Vector sub(Vector v1, Vector v2);
    public Vector div(Vector v, float f);
    public (Vector min, Vector max) minMax(Vector curMin, Vector curMax, Vector v);
    public Vector square(Vector v);
    public Vector[] squareList(Vector[] vA);
    public Vector[] arrAdd(Vector[] vA1, Vector[] vA2);
    public Vector[] arrSub(Vector[] vA1, Vector[] vA2);
    public Vector[] arrDiv(Vector[] vA, float f);
    public (Vector[] min, Vector[] max) arrMinMax(Vector[] curMin, Vector[] curMax, Vector[] vA);
    public Vector average(Vector[] vA);
    public Vector lowest(Vector[] vA);
}

public class VectorHelper : IVectorHelper{

    public VectorHelper(){}

    public (bool x, bool y, bool z) greaterEqual(Vector v1, Vector v2){
        return (
            v1.x >= v2.x,
            v1.y >= v2.y,
            v1.z >= v2.z
        );
    }

    public Vector add(Vector v1, Vector v2){
        return new Vector(
            v1.x + v2.x,
            v1.y + v2.y,
            v1.z + v2.z
        );
    }

    public Vector sub(Vector v1, Vector v2){
        return new Vector(
            v1.x - v2.x,
            v1.y - v2.y,
            v1.z - v2.z
        );
    }

    public Vector div(Vector v1, float f){
        return new Vector(
            v1.x/f,
            v1.y/f,
            v1.z/f
        );
    }

    public (Vector min, Vector max) minMax(Vector curMin, Vector curMax, Vector v){
        var flags = greaterEqual(curMin, v);
        if(flags.x) curMin.x = v.x;
        if(flags.y) curMin.y = v.y;
        if(flags.z) curMin.z = v.z;
        flags = greaterEqual(curMax, v);
        if(!flags.x) curMax.x = v.x;
        if(!flags.y) curMax.y = v.y;
        if(!flags.z) curMax.z = v.z;
        return (curMin, curMax);
    }

    public Vector square(Vector v){
        return new Vector{
            x = (float) Math.Pow(v.x, 2),
            y = (float) Math.Pow(v.y, 2),
            z = (float) Math.Pow(v.z, 2)
        };
    }

    public Vector[] squareList(Vector[] vA){
        var ret = new List<Vector>();
        foreach(var v in vA) ret.Add(square(v));
        return ret.ToArray();
    }

    public Vector[] arrAdd(Vector[] vA1, Vector[] vA2){
        int length = vA1.Length;
        Vector[] ret = new Vector[length];
        for(int i =0; i<length; i++){
            ret[i] = add(vA1[i], vA2[i]);
        }
        return ret;
    }

    public Vector[] arrSub(Vector[] vA1, Vector[] vA2){
        int length = vA1.Length;
        Vector[] ret = new Vector[length];
        for(int i =0; i<length; i++){
            ret[i] = sub(vA1[i],vA2[i]);
        }
        return ret;
    }

    public Vector[] arrDiv(Vector[] vA, float f){
        int length = vA.Length;
        Vector[] ret = new Vector[length];
        for(int i =0; i<length; i++){
            ret[i] = div(vA[i],f);
        }
        return ret;
    }

    public (Vector[] min, Vector[] max) arrMinMax(Vector[] curMin, Vector[] curMax, Vector[] vA){
        for (int i = 0; i < vA.Length; i++){
            (curMin[i], curMax[i]) = minMax(curMin[i], curMax[i], vA[i]);
        }
        return (curMin, curMax);
    }

    public Vector average(Vector[] vA){
        Vector ret = new Vector(0,0,0);
        for(int i = 0; i < vA.Length; i++){
            ret.x += vA[i].x;
            ret.y += vA[i].y;
            ret.z += vA[i].z;
        }
        ret.x /= (float) vA.Length;
        ret.y /= (float) vA.Length;
        ret.z /= (float) vA.Length;
        return ret;
    }

    public Vector lowest(Vector[] vA){
        Vector ret = vA[0];
        foreach (Vector v in vA) {
            if(v.y < ret.y){
                ret.x = v.x;
                ret.y = v.y;
                ret.z = v.z;
            }
        }
        return ret;
    }
}