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
        AmplitudeModulationControlPoint in1 = dg.newAmplitudeModulationControlPoint(); 
        AmplitudeModulationControlPoint in2 = dg.newAmplitudeModulationControlPoint();
    }
}