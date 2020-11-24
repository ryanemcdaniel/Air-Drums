using System;
using Leap;

public class Hand_Generator{

    private Data_Generator dg;

    public Hand_Generator(Data_Generator data_generator){
        dg = data_generator;
    }

    public Finger newFinger(){
        return new Finger(
            dg.newLong(100),
            dg.newInt(100),
            dg.newInt(100),
            dg.newFloat(100),
            dg.newVector(),
            dg.newVector(),
            dg.newVector(),
            dg.newVector(),
            dg.newFloat(100),
            dg.newFloat(100),
            false,
            Leap.Finger.FingerType.TYPE_INDEX,
            new Bone(),
            new Bone(),
            new Bone(),
            new Bone()
        );
    }

    public Hand newHand(){
        return new Hand{
            FrameId = dg.newLong(100),
            Id = dg.newInt(100),
            Confidence = dg.newFloat(100),
            GrabStrength = dg.newFloat(100),
            GrabAngle = dg.newFloat(100),
            PinchStrength = dg.newFloat(100),
            PinchDistance = dg.newFloat(100),
            PalmWidth = dg.newFloat(100),
            IsLeft = false,
            TimeVisible = dg.newFloat(100),
            Arm = null,
            Fingers = null,
            PalmPosition = dg.newVector(),
            StabilizedPalmPosition = dg.newVector(),
            PalmVelocity = dg.newVector(),
            PalmNormal = dg.newVector(),
            Rotation = new LeapQuaternion(),
            Direction = dg.newVector(),
            WristPosition = dg.newVector()
        };
    }
}