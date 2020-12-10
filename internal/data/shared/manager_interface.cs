using System.Security.AccessControl;
using Leap;
using System.Collections.Generic;

public interface IDataManager {
    public void Extract(Frame f);
    public (List<Joints> position, List<Joints> velocity) GetData();
}