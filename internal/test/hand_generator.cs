using System;
using Leap;

public class Hand_Generator{

    private Vec_Generator vg;

    public Hand_Generator(){
        vg = new Vec_Generator();
    }

    public Bone newBone(){
        return new Bone();
    }

    public Finger newFinger(){
        Finger ret = new Finger(
            vg.newLong(100),
            vg.newInt(100),
            vg.newInt(100),
            vg.newFloat(100),
            vg.newVector(),
            vg.newVector(),
            vg.newVector(),
            vg.newVector(),
            vg.newFloat(100),
            vg.newFloat(100),
            false,
            Leap.Finger.FingerType.TYPE_INDEX,
            newBone(),
            newBone(),
            newBone(),
            newBone()
        );
        return ret;
    }

    public Hand newHand(){
        Hand ret = new Hand();
        return ret;
    }
}