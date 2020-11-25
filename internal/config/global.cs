public class Global {

    public Global(){
        N_SAMPLES           = 0;    // Controls number of frames we analyze at a time
    
        DIV_Xn              = 0;    // -X divider for gesture box
        DIV_Xp              = 0;    // +X divider for gesture box
        DIV_Xn              = 0;
        DIV_Yp              = 0;
        DIV_Yn              = 0;
        DIV_Zp              = 0;
        DIV_Zn              = 0;
    
        THRSHLD_VEL_X       = 0;    // Idle threshold velocities
        THRSHLD_VEL_Y       = 0;
        THRSHLD_VEL_Z       = 0;

        TAP_THRSHLD_VEL_X   = 0;
        TAP_THRSHLD_VEL_Y   = 0;
        TAP_THRSHLD_VEL_Z   = 0;
        SWP_THRSHLD_VEL_X   = 0;
        SWP_THRSHLD_VEL_Y   = 0;
        SWP_THRSHLD_VEL_Z   = 0;
    }   

    public static int       N_SAMPLES;
    public static float     DIV_Xp;
    public static float     DIV_Xn;
    public static float     DIV_Yp;
    public static float     DIV_Yn;
    public static float     DIV_Zp;
    public static float     DIV_Zn;
    public static float     THRSHLD_VEL_X;
    public static float     THRSHLD_VEL_Y;
    public static float     THRSHLD_VEL_Z;
    public static float     TAP_THRSHLD_VEL_X;
    public static float     TAP_THRSHLD_VEL_Y;
    public static float     TAP_THRSHLD_VEL_Z;
    public static float     SWP_THRSHLD_VEL_X;
    public static float     SWP_THRSHLD_VEL_Y;
    public static float     SWP_THRSHLD_VEL_Z;
}