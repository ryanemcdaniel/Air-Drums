using System;
using Leap;
using System.Collections.Generic;
using System.Linq;

public class VectorHelper : IVectorHelper{

    public VectorHelper(){}

    public (Vector min, Vector max) minMax(Vector curMin, Vector curMax, Vector v){
        curMin = wholeVector((c1, c2) => c1 >= c2 ? c2 : c1, curMin, v);
        curMax = wholeVector((c1, c2) => c1 >= c2 ? c1 : c2, curMin, v);
        return (curMin, curMax);
    }

    public (bool x, bool y, bool z) greaterEqual(Vector v1, Vector v2){
        return (
            v1.x >= v2.x,
            v1.y >= v2.y,
            v1.z >= v2.z
        );
    }

    public Vector add(Vector v1, Vector v2) =>  wholeVector((x, y) => x + y, v1, v2);

    public Vector sub(Vector v1, Vector v2) =>  wholeVector((x, y) => x - y, v1, v2);

    public Vector div(Vector v, float f) =>     wholeVector((x, y) => x / y, v, f);

    public Vector pow(Vector v, float f) => wholeVector((x, y) => (float) Math.Pow(x, y), v, f);

    public Vector[] arrAdd(Vector[] vA1, Vector[] vA2)  => wholeVectorList(add, vA1, vA2);

    public Vector[] arrSub(Vector[] vA1, Vector[] vA2)  => wholeVectorList(sub, vA1, vA2);

    public Vector[] arrDiv(Vector[] vA, float f) => wholeVectorList(div, vA, f);
    
    public Vector[] powList(Vector[] vA, float f) => wholeVectorList(pow, vA, f);

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
                wholeVector((x, y) => x = y , ret, v);
            }
        }
        return ret;
    }

    public Vector[] wholeVectorList(Apply_Vectors toVectorList, Vector[] vL1, Vector[] vL2){
        var ret = new List<Vector>();
        foreach (var v in vL1.Zip(vL2)) 
            ret.Add(toVectorList(v.First, v.Second));
        return ret.ToArray();
    }

    public Vector[] wholeVectorList(Scale_Vectors toVectorList, Vector[] vL, float f){
        var ret = new List<Vector>();
        foreach (var v in vL) 
            ret.Add(toVectorList(v, f));
        return ret.ToArray();
    }

    public Vector wholeVector(Apply toComponent, Vector v1, Vector v2){
        return new Vector{
            x = toComponent(v1.x , v2.x),
            y = toComponent(v1.y , v2.y),
            z = toComponent(v1.z , v2.z)
        };
    }

    public Vector wholeVector(Apply toComponent, Vector v, float f){
        return new Vector{
            x = toComponent(v.x, f),
            y = toComponent(v.y, f),
            z = toComponent(v.z, f)
        };
    }
}