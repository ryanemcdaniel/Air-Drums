using Xunit;
using Moq;
using Leap;
using System.Collections.Generic;

public class queues_test {

    [Fact]
    public void Queue_GetSamples_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Queue_Generator qg = new Queue_Generator(hg);
        List<Hand> exp = qg.newHandList(dg.newInt(100));
        
        Queues q = new Queues(exp);
        List<Hand> act = q.GetSamples();

        test.handQueueEqual(exp, act);
    }

    [Fact]
    public void Load_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Queue_Generator qg = new Queue_Generator(hg);
        List<Hand> exp = qg.newHandList(dg.newInt(100));
    }

    [Fact]
    public void Load_SampleCount_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Queue_Generator qg = new Queue_Generator(hg);


    }

    [Fact]
    public void Load_SampleCount_Fails(){

    }
}