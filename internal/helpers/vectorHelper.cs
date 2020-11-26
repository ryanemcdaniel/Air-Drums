using Leap;


public interface IVectorHelper{
    public Vector add(Vector v1, Vector v2);
    public Vector sub(Vector v1, Vector v2);
    public Vector div(Vector v, float f);
    public (Vector, Vector) minMax(Vector v1, Vector v2);
    public Vector average(Vector[] vA);
    public Vector lowest(Vector[] vA);
    
}

public class VectorHelper : IVectorHelper{

    public VectorHelper(){}

    public Vector add(Vector v1, Vector v2){
        return new Vector();
    }

    public Vector sub(Vector v1, Vector v2){
        return new Vector(
            v1.x - v2.x,
            v1.y - v2.y,
            v1.z - v2.z
        );
    }

    public Vector div(Vector v1, float f){
        return new Vector();
    }

    public Vector[] arrAdd(Vector[] vA1, Vector[] vA2){
        return null;
    }

    public Vector[] arrSub(Vector[] vA1, Vector[] vA2){
        return null;
    }

    public Vector[] arrDiv(Vector[] vA, float f){
        return null;
    }

    public (Vector, Vector) minMax(Vector v1, Vector v2){
        return (new Vector(), new Vector());
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