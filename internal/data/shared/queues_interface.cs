using Leap;
using System.Collections.Generic;

public interface IQueues {
    public void LoadSample(Hand h, float f);
    public void Clear();
    public List<Hand> GetSamples();
    public List<Joints> GetPositions();
    public List<Joints> GetVelocities();
}