using Leap;

public interface IVectorHelper{
    public Vector   add     (Vector v1, Vector v2);
    public Vector   sub     (Vector v1, Vector v2);
    public Vector   div     (Vector v, float f);
    public Vector   pow     (Vector v, float f);
    public Vector[] addList (Vector[] vA1, Vector[] vA2);
    public Vector[] subList (Vector[] vA1, Vector[] vA2);
    public Vector[] divList (Vector[] vA, float f);
    public Vector[] powList (Vector[] vA, float f);
    public (Vector min, Vector max) minMax(Vector curMin, Vector curMax, Vector v);
    public (Vector[] min, Vector[] max) minMaxList(Vector[] curMin, Vector[] curMax, Vector[] vA);
    public Vector average(Vector[] vA);
    public Vector lowest(Vector[] vA);
} 