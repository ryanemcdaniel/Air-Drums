using System;
using Leap;


public interface IVectorHelper{
    public Vector add(Vector v1, Vector v2);
    public Vector sub(Vector v1, Vector v2);
    public Vector div(Vector v, float f);
    public (Vector, Vector) minMax(Vector v1, Vector v2);
    public Vector[] arrAdd(Vector[] vA1, Vector[] vA2);
    public Vector[] arrSub(Vector[] vA1, Vector[] vA2);
    public Vector[] arrDiv(Vector[] vA, float f);
    public (Vector[], Vector[]) arrMinMax(Vector[] vA1, Vector[] vA2);
    public Vector average(Vector[] vA);
    public Vector lowest(Vector[] vA);
    
}

public class VectorHelper : IVectorHelper{

    public VectorHelper(){}

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
    public (Vector, Vector) minMax(Vector v1, Vector v2){
        return (
            new Vector{
                x = v1.x >= v2.x ? v2.x : v1.x,
                y = v1.y >= v2.y ? v2.y : v1.y,
                z = v1.z >= v2.z ? v2.z : v1.z
            },
            new Vector{
                x = v1.x < v2.x ? v2.x : v1.x,
                y = v1.y < v2.y ? v2.y : v1.y,
                z = v1.z < v2.z ? v2.z : v1.z
            }  
        );
    }

    public Vector[] arrAdd(Vector[] vA1, Vector[] vA2){
        int length = vA1.Length;
        Vector[] ret = new Vector[length];
        for(int i =0; i<length; i++){
            ret[i].x = vA1[i].x + vA2[i].x;
            ret[i].y = vA1[i].y + vA2[i].y;
            ret[i].z = vA1[i].z + vA2[i].z;
        }
        return ret;
    }

    public Vector[] arrSub(Vector[] vA1, Vector[] vA2){
        int length = vA1.Length;
        Vector[] ret = new Vector[length];
        for(int i =0; i<length; i++){
            ret[i].x = vA1[i].x - vA2[i].x;
            ret[i].y = vA1[i].y - vA2[i].y;
            ret[i].z = vA1[i].z - vA2[i].z;
        }
        return ret;
    }

    public Vector[] arrDiv(Vector[] vA, float f){
        int length = vA.Length;
        Vector[] ret = new Vector[length];
        for(int i =0; i<length; i++){
            ret[i].x = vA[i].x / f;
            ret[i].y = vA[i].y / f;
            ret[i].z = vA[i].z / f;
        }
        return ret;
    }

    public (Vector[], Vector[]) arrMinMax(Vector[] vA1, Vector[] vA2){
        return (null, null);
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