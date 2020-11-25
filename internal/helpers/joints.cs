using Leap;

public class Joints {

    public Joints(){}
    public Joints(
        Vector[]    in1,
        Vector[]    in2,
        Vector[]    in3,
        Vector[]    in4,
        Vector[]    in5,
        Vector      in6
    ){
        pinky   =   in1;
        ring    =   in2;
        middle  =   in3;
        index   =   in4;
        thumb   =   in5;
        palm    =   in6;
    }

    public Vector[] pinky;
    public Vector[] ring;
    public Vector[] middle;
    public Vector[] index;
    public Vector[] thumb;
    public Vector   palm;
    public Vector   min;
    public Vector   max;
    public float    frameRate;
}