using Xunit;
using Moq;
using Leap;
using System.Collections.Generic;

public class queues_test {

    [Fact]
    public void Queue_GetSamples_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        List<Hand> exp = new List<Hand>();

        Queues q = new Queues(exp);
        List<Hand> act = q.GetSamples();

        test.handQueueEqual(exp, act);
    }
}