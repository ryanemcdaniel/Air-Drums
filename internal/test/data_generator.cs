using System;
using System.Collections.Generic;
using Leap;
using Ultrahaptics;

public class Data_Generator {

    private Random rand;

    public Data_Generator(){
        this.rand = new Random();
    }

    public int newInt(int range){
        return rand.Next(range) + 1;
    }

    public long newLong(long range){
        return rand.Next((int) range) + 1;
    }

    public float newFloat(float range){
        return (float)(rand.NextDouble() * range);
    }

    public Vector newVector(){
        return new Vector(this.newFloat(100), this.newFloat(100), this.newFloat(100));
    }

    public Vector[] newVectors(int len){
        Vector[] ret = new Vector[len];
        for(int i = 0; i < len; i++) ret[i] = this.newVector();
        return ret;
    }

    public List<Vector[]> newVectorsList(int num, int len){
        List<Vector[]> ret = new List<Vector[]>();
        for(int i = 0; i < num; i++) ret.Add(newVectors(len));
        return ret;
    }

    public AmplitudeModulationControlPoint newAmplitudeModulationControlPoint(){
        Vector3  Temp = new Vector3(this.newFloat(100),this.newFloat(100),this.newFloat(100));
        return new AmplitudeModulationControlPoint(Temp,this.newFloat(100),this.newFloat(100));
    }

}