using System.Collections.Generic;
using Leap;

public class Queues {

    private List<Hand> samples;

    public Queues(List<Hand> s){
        samples = s;
    }

    public void Load(Hand h){
        
    }

    public void Clear(){

    }

    public List<Hand> GetSamples() => samples;
}