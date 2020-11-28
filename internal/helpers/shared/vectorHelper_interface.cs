using Leap;

public interface IVectorHelper{

    public (bool x, bool y, bool z) greaterEqual(Vector v1, Vector v2);

    public Vector add(Vector v1, Vector v2);

    public Vector sub(Vector v1, Vector v2);

    public Vector div(Vector v, float f);

    public (Vector min, Vector max) minMax(Vector curMin, Vector curMax, Vector v);

    public Vector pow(Vector v, float f);

    public Vector[] powList(Vector[] vA, float f);

    public Vector[] arrAdd(Vector[] vA1, Vector[] vA2);

    public Vector[] arrSub(Vector[] vA1, Vector[] vA2);

    public Vector[] arrDiv(Vector[] vA, float f);

    public (Vector[] min, Vector[] max) arrMinMax(Vector[] curMin, Vector[] curMax, Vector[] vA);

    public Vector average(Vector[] vA);

    public Vector lowest(Vector[] vA);
}