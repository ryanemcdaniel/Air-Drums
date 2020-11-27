using System.Runtime.Intrinsics.X86;
using Leap;

public class Joints {

    public Joints(){
        pinky       =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        ring        =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        middle      =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        index       =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        thumb       =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        palm        =   new Vector();
        frameRate   =   0;
    }

    public Joints(bool min){
        pinky       =   new Vector[5];
        ring        =   new Vector[5];
        middle      =   new Vector[5];
        index       =   new Vector[5];
        thumb       =   new Vector[5];
        palm        =   new Vector(float.MinValue, float.MinValue, float.MinValue);
        frameRate   =   0;
        if(min){
            for(int i = 0 ; i < 5; i++) {
                pinky[i]    = new Vector(float.MinValue, float.MinValue, float.MinValue);      
                ring[i]     = new Vector(float.MinValue, float.MinValue, float.MinValue);
                middle[i]   = new Vector(float.MinValue, float.MinValue, float.MinValue);
                index[i]    = new Vector(float.MinValue, float.MinValue, float.MinValue);
                thumb[i]    = new Vector(float.MinValue, float.MinValue, float.MinValue);
            }
        }else{
            for(int i = 0 ; i < 5; i++) {
                pinky[i]    = new Vector(float.MaxValue, float.MaxValue, float.MaxValue);      
                ring[i]     = new Vector(float.MaxValue, float.MaxValue, float.MaxValue);
                middle[i]   = new Vector(float.MaxValue, float.MaxValue, float.MaxValue);
                index[i]    = new Vector(float.MaxValue, float.MaxValue, float.MaxValue);
                thumb[i]    = new Vector(float.MaxValue, float.MaxValue, float.MaxValue);
            }
            palm        =   new Vector(float.MaxValue, float.MaxValue, float.MaxValue);
        }
    }

    public Joints(
        Vector[]    in1,
        Vector[]    in2,
        Vector[]    in3,
        Vector[]    in4,
        Vector[]    in5,
        Vector      in6,
        float       in7
    ){
        pinky   =   in1;
        ring    =   in2;
        middle  =   in3;
        index   =   in4;
        thumb   =   in5;
        palm    =   in6;
        frameRate=  in7;
    }

    public Vector[] pinky;
    public Vector[] ring;
    public Vector[] middle;
    public Vector[] index;
    public Vector[] thumb;
    public Vector   palm;
    public float    frameRate;
}