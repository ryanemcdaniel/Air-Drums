using Leap;
using Ultrahaptics;
using System.Collections.Generic;

public interface IClassificationPipeline {

    public void ClassifyGesture();

    public int DispatchFromQuadrant();

}