using System;
using System.Diagnostics;
using System.Collections.Generic;
using Ultrahaptics;
using Leap;
using Xunit;
public class Haptic_Test{

    [Fact]
    public void Data_HapticSetPoint_Passes(){
        Data_Generator dg = new Data_Generator();
        AmplitudeModulationControlPoint point1= dg.newAmplitudeModulationControlPoint(); 
        AmplitudeModulationControlPoint point2= dg.newAmplitudeModulationControlPoint();
        AmplitudeModulationControlPoint res = Vec.subtract(in1, in2);
        Assert.Equal(in1.x - in2.x, res.x);
    }