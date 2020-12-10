using Leap;
using System.Collections.Generic;
using System;

public class DataManager : IDataManager {

    private IQueues data;
    private bool leftMode;

    public DataManager(IQueues q, bool isLeft){
        data = q;
        leftMode = isLeft;
    }

    public void Extract(Frame f){
        foreach(var h in f.Hands){
            if (h.IsLeft && leftMode) {
                data.LoadSample(h, f.CurrentFramesPerSecond);
                return;
            }
            else if (!h.IsLeft && !leftMode) {
                data.LoadSample(h, f.CurrentFramesPerSecond);
                return;
            }
        }
        data.Clear();
    }

    public (List<Joints> position, List<Joints> velocity) GetData() => (data.GetPositions(), data.GetVelocities());
}