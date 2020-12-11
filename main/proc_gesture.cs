using Leap;
using Ultrahaptics;
using System.Collections.Concurrent;
using Global;
using System;

public interface IProc_Gesture {

}

public class Proc_Gesture : IProc_Gesture {

    private IClassify gesture;
    private IDataManager cache;
    private IVectorHelper vh;
    private ConcurrentQueue<Frame> frameStream;
    private ConcurrentQueue<int> midiStream;
    private ConcurrentQueue<Joints> targetStream;
    private Frame curFrame;

    public Proc_Gesture(IClassify classify, IDataManager dataManager, IVectorHelper vectorHelper, 
                        ConcurrentQueue<Frame> inStream, ConcurrentQueue<int> midiOutStream,
                        ConcurrentQueue<Joints> targetOutStream) {
        gesture = classify;
        cache = dataManager;
        vh = vectorHelper;
        frameStream = inStream;
        midiStream = midiOutStream;
        targetStream = targetOutStream;
    }

    public void ClassificationPipeline() {
        for(;;) {
            if (frameStream.TryDequeue(out curFrame)) {

                cache.Extract(curFrame);
                var data = cache.GetData();
                gesture.Update(data.position, data.velocity);

                if (gesture.IsMovement()) {

                    if (gesture.IsTap()) {
                        Console.WriteLine("Tap!");
                        var curPos = data.position[GBL.N_SAMPLES - 1];
                        targetStream.Enqueue(curPos);
                        var quad = vh.IdentQuadrant(curPos.TipsNoThumb()[2]);
                        midiStream.Enqueue(quad);
                        continue;
                    }

                    if (GBL.CUSTOM_MODE || !GBL.RECORD && gesture.IsSwipeLeft()) {
                        midiStream.Enqueue(5);
                        GBL.PLAY = true;
                        GBL.RECORD = true;
                        GBL.STOP = false;
                        continue;
                    }

                    if (GBL.CUSTOM_MODE || !GBL.PLAY && gesture.IsSwipeRight()) {
                            midiStream.Enqueue(6);
                            GBL.PLAY = true;
                            GBL.STOP = false;
                            continue;
                        }

                    if (GBL.CUSTOM_MODE || !GBL.STOP && gesture.IsStop()) {
                        midiStream.Enqueue(7);
                        GBL.STOP = true;
                        GBL.RECORD = false;
                        GBL.PLAY = false;
                        continue;
                    }
                }
            }
        }
    }

}