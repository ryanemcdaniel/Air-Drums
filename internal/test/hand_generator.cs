using System.Collections.Generic;
using Leap;

public class Hand_Generator{

    private Data_Generator dg;

    public Hand_Generator(Data_Generator data_generator){
        dg = data_generator;
    }

    public Bone newBone(Vector joint1, Vector joint2) => new Bone{
        PrevJoint       = joint1,
        NextJoint       = joint2,
        Center          = dg.newVector(),
        Direction       = dg.newVector(),
        Length          = dg.newFloat(100),
        Width           = dg.newFloat(100),
        Type            = new Bone.BoneType()
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
        new bool(),
        new Finger.FingerType(),
        newBone(jointList[0], jointList[1]),
        newBone(jointList[1], jointList[2]),
        newBone(jointList[2], jointList[3]),
        newBone(jointList[3], jointList[4])
    );

    public List<Finger> newFingerList() => new List<Finger>{
        newFinger(dg.newVectors(5)),
        newFinger(dg.newVectors(5)),
        newFinger(dg.newVectors(5)),
        newFinger(dg.newVectors(5)),
        newFinger(dg.newVectors(5)),
    };

    public List<Finger> newFingerList(List<Vector[]> vL) => new List<Finger>{
        newFinger(vL[0]),
        newFinger(vL[1]),
        newFinger(vL[2]),
        newFinger(vL[3]),
        newFinger(vL[4]),
    };

    public Hand newHand(List<Finger> fL) => new Hand{
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
        Fingers = fL,
        PalmPosition = dg.newVector(),
        StabilizedPalmPosition = dg.newVector(),
        PalmVelocity = dg.newVector(),
        PalmNormal = dg.newVector(),
        Rotation = new LeapQuaternion(),
        Direction = dg.newVector(),
        WristPosition = dg.newVector()
    };

    public List<Hand> newHandList(int len) {
        List<Hand> ret = new List<Hand>();
        for( int i = 0; i < len; i++ ) {
            ret.Add(newHand(newFingerList(dg.newVectorsList(5,5))));
        }
        return ret;
    }

    public Joints newJoints() => new Joints(
        dg.newVectors(5),
        dg.newVectors(5),
        dg.newVectors(5),
        dg.newVectors(5),
        dg.newVectors(5),
        dg.newVector(),
        dg.newFloat(100)
    );
    
    public Joints zeroJoints() => new Joints(
        dg.newZeroVectors(5),
        dg.newZeroVectors(5),
        dg.newZeroVectors(5),
        dg.newZeroVectors(5),
        dg.newZeroVectors(5),
        dg.newVector(),
        0
    );

    public List<Joints> newJointsList(int len) {
        List<Joints> ret = new List<Joints>();
        for (int i = 0; i < len; i++) ret.Add(newJoints());
        return ret;
    }
    
    public Frame newFrame() {
        return new Frame{
            Id = dg.newLong(100),
            Timestamp = dg.newLong(100),
            CurrentFramesPerSecond = dg.newFloat(100),
            InteractionBox = new InteractionBox(),
            Hands = newHandList(2)
        };
    }
}