using Xunit;
using Moq;
using Leap;
using Global;
using System.Collections.Generic;

public class queues_test {

    [Fact]
    public void Load_Passes(){
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Queue_Generator qg = new Queue_Generator(hg);

        int exp_N_SAMPLES = dg.newInt(100);
        List<Hand> input = qg.newHandList(exp_N_SAMPLES + dg.newInt(100));

        List<Hand> exp = new List<Hand>(input);
        int i = 0;
        foreach (var h in input)
        {
            if(i++ < input.Count - exp_N_SAMPLES) exp.Remove(h);
        }

        int org_N_SAMPLES = GBL.N_SAMPLES;
        GBL.N_SAMPLES = exp_N_SAMPLES;
        Queues q = new Queues(new List<Hand>());
        foreach (var h in input){
            q.LoadSample(h);
        }
        List<Hand> act = q.GetSamples();

        GBL.N_SAMPLES = org_N_SAMPLES;
        Assert.Equal(exp_N_SAMPLES, act.Count);
        test.handQueueEqual(exp, act);
    }

    [Fact]
    public void Clear_Passes()
    {
        Data_Generator dg = new Data_Generator();
        Hand_Generator hg = new Hand_Generator(dg);
        Queue_Generator qg = new Queue_Generator(hg);

        int inp_N_SAMPLES = dg.newInt(100);
        List<Hand> inp_list = qg.newHandList(inp_N_SAMPLES + dg.newInt(100));

        List<Hand> exp_list = new List<Hand>();

        int org_N_SAMPLES = GBL.N_SAMPLES;
        GBL.N_SAMPLES = inp_N_SAMPLES;
        Queues q = new Queues(new List<Hand>());
        foreach (var h in inp_list){
            q.LoadSample(h);
        }
        q.Clear();
        List<Hand> act_list = q.GetSamples();

        GBL.N_SAMPLES = org_N_SAMPLES;
        Assert.Equal(exp_list.Count, act_list.Count);
        test.handQueueEqual(exp_list, act_list);
    }

}