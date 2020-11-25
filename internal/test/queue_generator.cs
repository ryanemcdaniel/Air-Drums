using Leap;
using System.Collections.Generic;

public class Queue_Generator {
    private Hand_Generator hg;

    public Queue_Generator(Hand_Generator hand_Generator){
        hg = hand_Generator;
    }

    public List<Hand> newHandList(int len) {
        List<Hand> ret = new List<Hand>();
        for(int i = 0; i < len; i++){
            ret.Add(hg.newHand());
        }
        return ret;
    }
}