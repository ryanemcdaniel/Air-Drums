using Leap;
using System.Collections.Concurrent;
using Global;

public class Proc_Data : IProc {
    
    private Controller c;
    private ConcurrentQueue<Frame> leftStream;
    private ConcurrentQueue<Frame> rightStream;

    public Proc_Data(Controller controller, ConcurrentQueue<Frame> left, ConcurrentQueue<Frame> right) {
        c = controller;
        leftStream = left;
        rightStream = right;
    }

    public void Pipeline() {
        Frame curFrame = c.Frame();
        leftStream.Enqueue(curFrame);
        System.Threading.Thread.Sleep(GBL.N_POLLING_TIME / 2);
        rightStream.Enqueue(curFrame);
        System.Threading.Thread.Sleep(GBL.N_POLLING_TIME / 2);
    }

}