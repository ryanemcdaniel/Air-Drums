using System;
using Leap;

public class Data_Generator {

    private Random rand;

    public Data_Generator(){
        this.rand = new Random();
    }

    public float newFloat(float range){
        return (float)(rand.NextDouble() * range);
    }

    public Vector newVector(){
        return new Vector(this.newFloat(100), this.newFloat(100), this.newFloat(100));
    }
}