using System;
using System.Collections.Generic;
using Leap;
using System.Linq;

public partial class VectorHelper : IVectorHelper{

    public VectorHelper(){}

    // Basic vector operations
    public Vector   add     (Vector v1, Vector v2)          => wholeVector( (x, y) => x + y, v1, v2 );
    public Vector   sub     (Vector v1, Vector v2)          => wholeVector( (x, y) => x - y, v1, v2 );
    public Vector   div     (Vector v, float f)             => wholeVector( (x, y) => x / y, v, f );
    public Vector   pow     (Vector v, float f)             => wholeVector( (x, y) => (float) Math.Pow(x, y), v, f );
    public Vector   min     (Vector min, Vector v)          => wholeVector( (x, y) => x >= y ? y : x, min, v );
    public Vector   max     (Vector max, Vector v)          => wholeVector( (x, y) => x >= y ? x : y, max, v );

    // Vector operations over entire list
    public Vector[] addList (Vector[] vA1, Vector[] vA2)    => wholeVectorList( add, vA1, vA2 );
    public Vector[] subList (Vector[] vA1, Vector[] vA2)    => wholeVectorList( sub, vA1, vA2 );
    public Vector[] divList (Vector[] vA, float f)          => wholeVectorList( div, vA, f );
    public Vector[] powList (Vector[] vA, float f)          => wholeVectorList( pow, vA, f );

    // Vector comparisons
    public (bool x, bool y, bool z) greaterEqual(Vector v1, Vector v2) => ( v1.x >= v2.x, v1.y >= v2.y, v1.z >= v2.z );
    
    public (bool x, bool y, bool z)[] greaterEqualList(Vector[] vA1, Vector[] vA2){
        var ret = new List<(bool, bool, bool)>();
        foreach (var v in vA1.Zip(vA2)) ret.Add(greaterEqual(v.First, v.Second));
        return ret.ToArray();
    }
    
    public (Vector min, Vector max) minMax(Vector curMin, Vector curMax, Vector v) => (min(curMin, v), max(curMax, v));

    public (Vector[] min, Vector[] max) minMaxList(Vector[] curMin, Vector[] curMax, Vector[] vA){
        (var retMin, var retMax) = (new Vector[curMin.Length], new Vector[curMin.Length]);
        for (int i = 0; i < vA.Length; i++){
            (retMin[i], retMax[i]) = minMax(curMin[i], curMax[i], vA[i]);
        }
        return (retMin, retMax);
    }

    public Vector lowest(Vector[] vA) {
        Vector ret = vA[0];
        foreach (Vector v in vA) {
            if(v.y < ret.y) wholeVector((x, y) => x = y , ret, v);
        }
        return ret;
    }

    public Vector average(Vector[] vA) {
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

}