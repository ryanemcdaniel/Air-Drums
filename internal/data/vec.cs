using Leap;

public static class Vec{
    
    public static Vector subtract(Vector v1, Vector v2){
        return new Vector(
            v1.x - v2.x,
            v1.y - v2.y,
            v1.z - v2.z
        );
    }

    public static Vector velocity(Vector v1, Vector v2, float frameRate){
        Vector ret = subtract(v1, v2);
        ret.x /= frameRate;
        ret.y /= frameRate;
        ret.z /= frameRate;
        return ret;
    }

    public static bool greater(Vector v1, Vector v2, char mode){
        if(mode == 'x') return v1.x > v2.x;
        if(mode == 'y') return v1.y > v2.y;
        if(mode == 'z') return v1.z > v2.z;
        return false;
    }

}