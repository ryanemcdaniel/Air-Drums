using System;
using Leap;
using Ultrahaptics;

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

    public AmplitudeModulationControlPoint newAmplitudeModulationControlPoint(){
        Vector3  Temp = new vector3(this.newFloat(100),this.newFloat(100),this.newFloat(100));
        return new AmplitudeModulationControlPoint(Temp,this.newFloat(100),this.newFloat(100));
    }

}