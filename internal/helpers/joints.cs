using Leap;

public class Joints {

    public Vector[] pinky;
    public Vector[] ring;
    public Vector[] middle;
    public Vector[] index;
    public Vector[] thumb;
    public Vector   palm;
    public float    frameRate;

    public Joints(){
        pinky       =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        ring        =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        middle      =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        index       =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        thumb       =   new[]{new Vector(), new Vector(), new Vector(), new Vector(), new Vector()};
        palm        =   new Vector();
        frameRate   =   0;
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
        pinky     = in1;
        ring      = in2;
        middle    = in3;
        index     = in4;
        thumb     = in5;
        palm      = in6;
        frameRate = in7;
    }

    public Joints Clone() {
        return new Joints{
            pinky     = this.pinky    ,
            ring      = this.ring     ,
            middle    = this.middle   ,
            index     = this.index    ,
            thumb     = this.thumb    ,
            palm      = this.palm     ,
            frameRate = this.frameRate
        };
    }

    public Vector[] Tips() => new[]{pinky[4], ring[4], middle[4], index[4], thumb[4]};

    public Vector[] ToArray() {
        var ret = new Vector[26];
        pinky  .CopyTo(ret, 0);
        ring   .CopyTo(ret, 5);
        middle .CopyTo(ret, 10);
        index  .CopyTo(ret, 15);
        thumb  .CopyTo(ret, 20);
        ret[25] = palm;
        return ret;
    }
    
    public string TipsToString() {
        return  "Finger Tips:\n" + 
                "pinky  =" + pinky [4].ToString() + "\n" +
                "ring   =" + ring  [4].ToString() + "\n" +
                "middle =" + middle[4].ToString() + "\n" +
                "index  =" + index [4].ToString() + "\n" +
                "thumb  =" + thumb [4].ToString() + "\n";
    }
}