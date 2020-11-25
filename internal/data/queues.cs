using Leap;
using Global;
using System.Collections.Generic;

public interface IQueues {
    public List<Hand> GetSamples();
    public void LoadSample(Hand h);
    public void Clear();
}

public class Queues : IQueues {

    private JointsHelper jH;

    private List<Hand> samples;
    private List<Joints> position;
    private List<Joints> velocity;

    public Queues(JointsHelper jointsHelper){
        jH = jointsHelper;
        samples = new List<Hand>();
        position = new List<Joints>();
        velocity = new List<Joints>();
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