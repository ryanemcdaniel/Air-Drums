using Leap;


public interface IVectorHelper{
    public Vector add(Vector v1, Vector v2);
    public Vector sub(Vector v1, Vector v2);
    public Vector velocity(Vector v1, Vector v2, float f);
    public Vector average(Vector[] vA);
    public Vector range(Vector[] vA);
    public Vector min(Vector[] vA);
    public Vector max(Vector[] vA);
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

    public Vector velocity(Vector v1, Vector v2, float frameRate){
        Vector ret = sub(v1, v2);
        ret.x /= frameRate;
        ret.y /= frameRate;
        ret.z /= frameRate;
        return ret;
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

    public Vector range(Vector[] vA){
        return new Vector();
    }

    public Vector min(Vector[] vA){
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

    public Vector max(Vector[] vA){
        return new Vector();
    }
}