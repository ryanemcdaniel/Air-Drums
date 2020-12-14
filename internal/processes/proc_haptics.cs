using System.Collections.Concurrent;
using System.Collections.Generic;
using Ultrahaptics;
using Global;

public class Proc_Haptics : IProc {

    private IHaptic haptics;
    private ConcurrentQueue<Joints> jointsStream;
    private List<AmplitudeModulationControlPoint> targets;
    private List<int> remainingTimes;
    private Joints fromStream;
    private int uh_time;
    
    public Proc_Haptics(IHaptic haptic, ConcurrentQueue<Joints> inStream, 
                                List<AmplitudeModulationControlPoint> ampPoints, List<int> times) {
        haptics = haptic;
        jointsStream = inStream;
        targets = ampPoints;
        remainingTimes = times;
        uh_time = GBL.UH_TIME;
    }

    public void Pipeline() {
        if (GBL.DOG_FRIENDLY) System.Threading.Thread.Sleep(5000);
        else {
            if (jointsStream.TryDequeue(out fromStream)) {
                var target = haptics.AquireTarget(fromStream);
                targets.Add(target);
                remainingTimes.Add(uh_time);
            }

            haptics.Emit(targets);
            System.Threading.Thread.Sleep(10);

            for (int i = 0; i < remainingTimes.Count; i++) {
                if (remainingTimes[i]-- == 0) {
                    targets.RemoveAt(i);
                }
            }

            remainingTimes.RemoveAll(time => time <= -1);
        }
    }
}