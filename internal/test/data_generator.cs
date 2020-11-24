using System;
using Leap;

public class Data_Generator {

    private Random rand;

    public Data_Generator(){
        this.rand = new Random();
    }

    public int newInt(int range){
        return rand.Next(range);
    }

    public long newLong(long range){
        return rand.Next((int) range);
    }

    public float newFloat(float range){
        return (float)(rand.NextDouble() * range);
    }

    public Vector newVector(){
        return new Vector(this.newFloat(100), this.newFloat(100), this.newFloat(100));
    }

    public Vector[] newVectorList(int len){
        Vector[] ret = new Vector[len];
        for(int i = 0; i < len; i++) ret[i] = this.newVector();
        return ret;
    }

    public Bone newBone(){
        return new Bone();
    }

    public Finger newFinger(){
        Finger ret = new Finger(
            newLong(100),
            newInt(100),
            newInt(100),
            newFloat(100),
            newVector(),
            newVector(),
            newVector(),
            newVector(),
            newFloat(100),
            newFloat(100),
            false,
            Leap.Finger.FingerType.TYPE_INDEX,
            newBone(),
            newBone(),
            newBone(),
            newBone()
        );
        return ret;
    }

    public Hand newHand(){
        Hand ret = new Hand();
        return ret;
    }

}