using System.Collections.Generic;
using Leap;

public interface IStats {
    public Joints sum(List<Joints> jL);
    public Joints ave(List<Joints> jL);
    public Joints range(List<Joints> jL);
    public List<Joints> velocities(List<Joints> jL);
}

public class Stats : IStats {

    private IJointsHelper jh;

    public Stats(IJointsHelper jointsHelper) {
        jh = jointsHelper;
    }

    public Joints sum(List<Joints> jL){
        Joints ret = new Joints();
        foreach (Joints j in jL){
            ret = jh.add(ret, j);
        }
        return ret;
    }

    public Joints ave(List<Joints> jL) {
        return jh.div(sum(jL), jL.Count);
    }

    public Joints range(List<Joints> jL){
        (Joints min, Joints max) = jh.minMax(jL);
        return jh.sub(max, min);
    }

    public List<Joints> velocities(List<Joints> jL){
        return null;
    }
}