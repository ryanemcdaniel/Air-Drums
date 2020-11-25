using Leap;
using Global;
using System.Collections.Generic;

public interface IQueues {
    public List<Hand> GetSamples();
    public void LoadSample(Hand h);
    public void Clear();
}

public class Queues : IQueues {

    private List<Hand> samples;

    public Queues(List<Hand> s){
        samples = s;
    }

    public List<Hand> GetSamples() => samples;

    public void LoadSample(Hand h){
        samples.Add(h);
        if(samples.Count > GBL.N_SAMPLES) samples.RemoveAt(0);
    }

    public void Clear(){
        samples.Clear();
    }
}