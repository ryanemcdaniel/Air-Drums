using Leap;
using System.Collections.Concurrent;
using Ultrahaptics;
using Global;

public interface IProcesses {

}

public class Processes : IProcesses {

    private IController leapMotion;
    private IDataManager leftCache;
    private IDataManager rightCache;
    private IClassify gesture;
    private IHaptic haptics;

    private ConcurrentQueue<Frame> leftFrameStreams;
    private ConcurrentQueue<Frame> rightFrameStreams;
    private ConcurrentQueue<Hand> hapticStream;

    public Processes(IController lm, IDataManager ldm, IDataManager rdm, IClassify c, IHaptic h) {
        leapMotion = lm;
        leftCache = ldm;
        rightCache = rdm;
        gesture = c;
        haptics = h;


        leftFrameStreams = new ConcurrentQueue<Frame>();
        rightFrameStreams = new ConcurrentQueue<Frame>();
        hapticStream = new ConcurrentQueue<Hand>();
    }

    public void PollLeapMotionController() {
        for(;;) {
            // Acquire frame directly from LeapMotion service
            Frame curFrame = leapMotion.Frame();

            // Signal calculation threads
            leftFrameStreams.Enqueue(curFrame);
            rightFrameStreams.Enqueue(curFrame);

            // Wait designated amount of polling time;
            System.Threading.Thread.Sleep(GBL.N_POLLING_MILISECONDS);
        }
    }

    public void LeftHandStoreCalculate() {
        Frame curFrame;
        for(;;) {
            if (rightFrameStreams.TryDequeue(out curFrame)) {

                leftCache.Extract(curFrame);
                var pos = leftCache.positions();
                var vel = leftCache.velocities();

                var leftMoved = gesture.IsMovement(pos.left);

                if (leftMoved) {

                    if (gesture.IsTap(pos.left, vel.left)) {


                    }


                }
            }
        }
    }

    public void RightHandStoreCalculate() {
        Frame curFrame;
        for(;;) {

            // Upon successful queue consumption
            if (leftFrameStreams.TryDequeue(out curFrame)) {

                leftCache.Extract(curFrame);
                var pos = leftCache.positions();
                var vel = leftCache.velocities();

                var leftMoved = gesture.IsMovement(pos.left);
                var rightMoved = gesture.IsMovement(pos.right);

                if (rightMoved) {
                    
                    if (gesture.IsTap(pos.right, vel.right)) {



                    }
                }

            }
        }
    }

    public void UpdateHapticsEmissions() {

    }

}