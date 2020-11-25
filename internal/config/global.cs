using Leap;

public static class Global {

    static Global(){
        N_SAMPLES           = 0;    // Controls number of frames we analyze at a time
    }

    public static int       N_SAMPLES;
    public static Vector    DIV_P;
    public static Vector    DIV_N;
    public static Vector    TAP_VEL;
    public static Vector    SWP_VEL;
}