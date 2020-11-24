using System.Collections.Generic;
using Leap;



public class Queues {

    private Queue<Hand> samples;

    public Queues(){
        samples = new Queue<Hand>();
    }

    public void Load(Hand h){

    }

    public void Clear(){
        
    }

    public Queue<Hand> GetSamples() => samples;
}