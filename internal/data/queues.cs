using System;
using Leap;
using Global;
using System.Collections.Generic;

public class Queues : IQueues {

    private IJointsHelper jh;

    private List<Hand> samples;
    private List<Joints> positions;
    private List<Joints> velocities;

    public Queues(IJointsHelper jointsHelper){
        jh = jointsHelper;
        samples = new List<Hand>();
        positions = new List<Joints>();
        velocities = new List<Joints>();
    }

    public void LoadSample(Hand h, float fps){
        samples.Add(h);
        positions.Add(jh.handToJoints(h));

        if(samples.Count > 1){
            var temp = jh.sub(positions[positions.Count - 1], positions[positions.Count - 2]);
            velocities.Add(jh.div(temp, 0.02f));
        }

        if(samples.Count > GBL.N_SAMPLES){
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