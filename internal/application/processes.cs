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
    private ConcurrentQueue<int> leftMIDIStream;
    private ConcurrentQueue<int> rightMIDIStream;

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
                        var quad = vecHelp.IdentQuadrant(curPos.TipsNoThumb()[2]);
                        leftMIDIStream.Enqueue(quad);
                    }
                }
            }
        }
    }

    public void RightHandStoreCalculate() {
        Frame curFrame;
        for(;;) {
            if (leftFrameStreams.TryDequeue(out curFrame)) {

                leftCache.Extract(curFrame);
                var pos = leftCache.positions();
                var vel = leftCache.velocities();
                var rightMoved = gesture.IsMovement(pos.right);

                if (rightMoved) {
                    if (gesture.IsTap(pos.right, vel.right)) {
                        var curPos = pos.right[GBL.N_SAMPLES - 1];
                        hapticStream.Enqueue(curPos);
                        var quad = vecHelp.IdentQuadrant(curPos.TipsNoThumb()[2]);
                        leftMIDIStream.Enqueue(quad);
                    }
                }

            }
        }
    }
    public void UpdateHapticsEmissions() {

    }

    public void LeftDispatchMIDI() {
        int type;
        for(;;){
            if (leftMIDIStream.TryDequeue(out type)) {
                switch (type) {
                    // Quadrants commands
                    case 1:  leftPort.sendMIDI(CMD.LEFT_TAP_QUAD_1      );  break;
                    case 2:  leftPort.sendMIDI(CMD.LEFT_TAP_QUAD_2      );  break;
                    case 3:  leftPort.sendMIDI(CMD.LEFT_TAP_QUAD_3      );  break;
                    case 4:  leftPort.sendMIDI(CMD.LEFT_TAP_QUAD_4      );  break;
                    
                    // Transport commands
                    case 5:  leftPort.sendMIDI(CMD.LEFT_SWIPE_LEFT      );  break;
                    case 6:  leftPort.sendMIDI(CMD.LEFT_SWIPE_RIGHT     );  break;
                    case 7:  leftPort.sendMIDI(CMD.LEFT_STOP            );  break;
                    default: break;
                }   
            }
        }
    }

    public void RightDispatchMIDI() {
        int type;
        for(;;){
            if (leftMIDIStream.TryDequeue(out type)) {
                switch (type) {
                    // Quadrants commands
                    case 1:  rightPort.sendMIDI(CMD.RIGHT_TAP_QUAD_1    );  break;
                    case 2:  rightPort.sendMIDI(CMD.RIGHT_TAP_QUAD_2    );  break;
                    case 3:  rightPort.sendMIDI(CMD.RIGHT_TAP_QUAD_3    );  break;
                    case 4:  rightPort.sendMIDI(CMD.RIGHT_TAP_QUAD_4    );  break;
                    
                    // Transport commands
                    case 5:  rightPort.sendMIDI(CMD.RIGHT_SWIPE_LEFT    );  break;
                    case 6:  rightPort.sendMIDI(CMD.RIGHT_SWIPE_RIGHT   );  break;
                    case 7:  rightPort.sendMIDI(CMD.RIGHT_STOP          );  break;
                    default: break;
                }
            }
        }
    }

}