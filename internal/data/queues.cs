using Leap;
using System.Collections.Generic;
using Global;

public class Queues : IQueues {

    private IJointsHelper jh;

    private List<Hand> samples;
    private List<Joints> positions;
    private List<Joints> velocities;
    private int n_samples;

    public Queues(IJointsHelper jointsHelper){
        jh = jointsHelper;
        samples = new List<Hand>();
        positions = new List<Joints>();
        velocities = new List<Joints>();
        n_samples = GBL.N_SAMPLES;
    }

    public void LoadSample(Hand h, float fps){
        samples.Add(h);
        positions.Add(jh.handToJoints(h));

        if (samples.Count == 1) velocities.Add(new Joints());

        if (samples.Count > 1) {
            var temp = jh.sub(positions[positions.Count - 1], positions[positions.Count - 2]);
            velocities.Add(jh.div(temp, 0.02f));
        }

        if (samples.Count > n_samples) {
            samples.RemoveAt(0);
            positions.RemoveAt(0);
            velocities.RemoveAt(0);
        }
    }

    public void Clear(){
        samples.Clear();
        positions.Clear();
        velocities.Clear();
    }

    public List<Hand> GetSamples() => samples;
    public List<Joints> GetPositions() => positions;
    public List<Joints> GetVelocities() => velocities;
}