using Leap;

namespace Global {
    public static class GBL {

        static GBL(){
            N_SAMPLES           = 10;            // Controls number of frames we analyze at a time

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

            TAP_VEL_RANGE             = new Vector{
                x = 0,
                y = 300,
                z = 0
            };

            TAP_POS_RANGE             = new Vector{
                x = 75,
                y = 125,
                z = 75
            };

            TAP_VEL_AVE             = new Vector{
                x = 0,
                y = -100,
                z = 0
            };
            
            SWP_VEL             = new Vector{
                x = 0,
                y = 0,
                z = 0
            };

            NO_GESTURE_RANGE = new Vector{
                x = 100,
                y = 100,
                z = 100
            };
        }

        public static int       N_SAMPLES;
        
        public static float     UH_INTENSITY;

        public static float     UH_FREQUENCY;

        public static Vector    DIV_P;
        public static Vector    DIV_N;
        public static Vector    TAP_VEL_AVE;
        public static Vector    TAP_VEL_RANGE;
        public static Vector    TAP_POS_RANGE;
        public static Vector    SWP_VEL;
        public static Vector    NO_GESTURE_RANGE;
    }
}