using Leap;

namespace Global {
        public static class GBL {

        static GBL(){
            N_SAMPLES           = 0;            // Controls number of frames we analyze at a time

            UH_FREQUENCY        = 0;

            UH_INTENSITY        = 0;
            
            DIV_P               = new Vector{   
                x = 0,
                y = 0,
                z = 0
            };

            DIV_N               = new Vector{
                x = 0,
                y = 0,
                z = 0
            };

            TAP_VEL             = new Vector{
                x = 0,
                y = 0,
                z = 0
            };
            
            SWP_VEL             = new Vector{
                x = 0,
                y = 0,
                z = 0
            };
        }

        public static int       N_SAMPLES;
        
        public static float     UH_INTENSITY;

        public static float     UH_FREQUENCY;

        public static Vector    DIV_P;
        public static Vector    DIV_N;
        public static Vector    TAP_VEL;
        public static Vector    SWP_VEL;
    }
}