using System.Collections.Generic;

public interface IStats {
    public Joints sum(List<Joints> jL);
    public Joints average(List<Joints> jL);
    public Joints range(List<Joints> jL);
    public Joints variance(List<Joints> jL);
}