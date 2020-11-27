using System.Collections.Generic;
using Leap;

public interface IStats {
    public Joints sum(List<Joints> jL);
    public Joints average(List<Joints> jL);
    public Joints range(List<Joints> jL);
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

    public Joints average(List<Joints> jL) {
        return jh.div(sum(jL), jL.Count);
    }

    public Joints range(List<Joints> jL){
        (var min, var max) = (new Joints(false), new Joints(true));
        foreach (var j in jL) {
            (min, max) = jh.minMax(min, max, j);
        }
        return jh.sub(max, min);
    }

    public Joints variance(List<Joints> jL){
        return null;
    }
}