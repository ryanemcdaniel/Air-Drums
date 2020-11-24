using System.Collections.Generic;
using Leap;

public class Hand_Generator{

    private Data_Generator dg;

    public Hand_Generator(Data_Generator data_generator){
        dg = data_generator;
    }

    public Bone newBone(Vector joint1, Vector joint2) => new Bone{
        PrevJoint = joint1,
        NextJoint = joint2,
        Center = dg.newVector(),
        Direction = dg.newVector(),
        Length = dg.newFloat(100),
        Width  = dg.newFloat(100),
        Type = Leap.Bone.BoneType.TYPE_INVALID
    };

    public Finger newFinger(Vector[] jointList) => new Finger(
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
        newBone(jointList[0], jointList[1]),
        newBone(jointList[1], jointList[2]),
        newBone(jointList[2], jointList[3]),
        newBone(jointList[3], jointList[4])
    );

    public List<Finger> newFingerList() => new List<Finger>{
        newFinger(dg.newVectorList(5)),
        newFinger(dg.newVectorList(5)),
        newFinger(dg.newVectorList(5)),
        newFinger(dg.newVectorList(5)),
        newFinger(dg.newVectorList(5)),
    };

    public Hand newHand() => new Hand{
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
        Arm = new Arm(),
        Fingers = newFingerList(),
        PalmPosition = dg.newVector(),
        StabilizedPalmPosition = dg.newVector(),
        PalmVelocity = dg.newVector(),
        PalmNormal = dg.newVector(),
        Rotation = new LeapQuaternion(),
        Direction = dg.newVector(),
        WristPosition = dg.newVector()
    };
}