using System.Collections.Generic;
using Leap;

public class Queues {

    private Queue<Hand> samples;

    public Queues(HandHelper handHelper){
        samples = new Queue<Hand>();
    }

    private bool canCalculate(){
        return samples.Count < Global.N_SAMPLES;
    }

    public void Load(Hand h){

    }

    public void Clear(){
        
    }

    public Queue<Hand> GetSamples() => samples;
}