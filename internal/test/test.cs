using Xunit;
using Leap;
using System.Collections.Generic;
using System.Linq;

public static class test {
    
    public static void vectorEqual(Vector v1, Vector v2){
        Assert.Equal(v1.x, v2.x);
        Assert.Equal(v1.y, v2.y);
        Assert.Equal(v1.z, v2.z);
    }

    public static void vectorListEqual(Vector[] vL1, Vector[] vL2){
        Assert.Equal(vL1.Length, vL2.Length);
        for(int i = 0; i < vL1.Length; i++){
            vectorEqual(vL1[i], vL2[i]);
        }
    }

    public static void boneEqual(Bone b1, Bone b2){
        vectorEqual(b1.PrevJoint, b2.PrevJoint);
        vectorEqual(b1.Center   , b2.Center);
        vectorEqual(b1.NextJoint, b2.NextJoint);
        vectorEqual(b1.Direction, b2.Direction);
        Assert.Equal(b1.Length, b2.Length);
        Assert.Equal(b1.Type, b2.Type);
        Assert.Equal(b1.Width, b2.Width);
    }

    public static void fingerEqual(Finger f1, Finger f2){
        Assert.Equal(f1.bones.Length, f2.bones.Length);
        for(int i = 0; i < f1.bones.Length; i++){
            boneEqual(f1.bones[i], f2.bones[i]);
        }
        vectorEqual(f1.Direction, f2.Direction);
        vectorEqual(f1.StabilizedTipPosition, f1.StabilizedTipPosition);
        vectorEqual(f1.TipPosition, f2.TipPosition);
        vectorEqual(f1.TipVelocity, f2.TipVelocity);
        Assert.Equal(f1.HandId, f2.HandId);
        Assert.Equal(f1.Id, f2.Id);
        Assert.Equal(f1.IsExtended, f2.IsExtended);
        Assert.Equal(f1.Length, f2.Length);
        Assert.Equal(f1.TimeVisible, f2.TimeVisible);
        Assert.Equal(f1.Type, f2.Type);
        Assert.Equal(f1.Width, f2.Width);
    }

    public static void handEqual(Hand h1, Hand h2){
        Assert.Equal(h1.Fingers.Count, h2.Fingers.Count);
        Finger[] fArr1 = h1.Fingers.ToArray();
        Finger[] fArr2 = h2.Fingers.ToArray();
        for(int i = 0; i < fArr1.Length; i++){
            fingerEqual(fArr1[i], fArr2[i]);
        }
        vectorEqual(h1.PalmNormal, h2.PalmNormal);
        vectorEqual(h1.PalmPosition, h2.PalmPosition);
        vectorEqual(h1.PalmVelocity, h2.PalmVelocity);
        vectorEqual(h1.StabilizedPalmPosition, h2.StabilizedPalmPosition);
        vectorEqual(h1.WristPosition, h2.WristPosition);
        Assert.Equal(h1.Confidence, h2.Confidence);
        Assert.Equal(h1.FrameId, h2.FrameId);
        Assert.Equal(h1.GrabAngle, h2.GrabAngle);
        Assert.Equal(h1.GrabStrength, h2.GrabStrength);
        Assert.Equal(h1.Id, h2.Id);
        Assert.Equal(h1.IsLeft, h2.IsLeft);
        Assert.Equal(h1.PalmWidth, h2.PalmWidth);
        Assert.Equal(h1.PinchDistance, h2.PinchStrength);
        Assert.Equal(h1.TimeVisible, h2.TimeVisible);
    }

    public static void handQueueEqual(List<Hand> q1, List<Hand> q2){
        Assert.Equal(q1.Count, q2.Count);
        int[] aye = new int[5];
        var hands = q1.Zip(q2, (h1, h2) => new {Hand1 = h1, Hand2 = h2});
        foreach (var h in hands){
            handEqual(h.Hand1, h.Hand2);
        }
    }

}