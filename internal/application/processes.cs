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
    private IPort leftPort;
    private IPort rightPort;
    private IVectorHelper vecHelp;

    private ConcurrentQueue<Frame> leftFrameStreams;
    private ConcurrentQueue<Frame> rightFrameStreams;
    private ConcurrentQueue<Joints> hapticStream;

    public Processes(IController lm, IDataManager ldm, IDataManager rdm, IClassify c, 
                        IHaptic h, IPort lp, IPort rp, IVectorHelper vh) {
        leapMotion = lm;
        leftCache = ldm;
        rightCache = rdm;
        gesture = c;
        haptics = h;

        leftPort = lp;
        rightPort = rp;
        vecHelp = vh;

        leftFrameStreams = new ConcurrentQueue<Frame>();
        rightFrameStreams = new ConcurrentQueue<Frame>();
        hapticStream = new ConcurrentQueue<Joints>();
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
                        var curPos = pos.left[GBL.N_SAMPLES - 1];
                        hapticStream.Enqueue(curPos);
                        switch (vecHelp.IdentQuadrant(curPos.TipsNoThumb()[2])) {
                            default: break;
                            
                            // Quad 1
                            case 1:
                                break;

                            // Quad 2
                            case 2:
                                break;

                            // Quad 3
                            case 3:
                                break;

                            // Quad 4
                            case 4:
                                break;
                        }
                    } else {

                        // TODO
                        var swiped = gesture.IsSwipe();



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