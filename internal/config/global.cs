using Leap;
using System;

namespace Global {
    public static class GBL {

        public static int       N_SAMPLES = 10;
        public static int       N_LOOKBACK = 9;
        
        public static float     UH_INTENSITY = 1.0f;
        public static float     UH_FREQUENCY = 200.0f;
        
        public static Vector    TAP_VEL_RANGE             = new Vector{
            x = 0,
            y = 3000,
            z = 0
        };
        
        public static Vector    TAP_VEL_AVE             = new Vector{
            x = 0,
            y = -150,
            z = 0
        };
        
        public static Vector    TAP_POS_RANGE             = new Vector{
            x = 75,
            y = 125,
            z = 75
        };

        public static Vector    NO_GESTURE_RANGE = new Vector{
            x = 100,
            y = 100,
            z = 100
        };

        public static void VelocityLookback(float v) {
            if (GBL.N_LOOKBACK == 1) return;

            if (v < 0) GBL.N_LOOKBACK = 1;
        }

        public static void LookbackReset() {
            GBL.N_LOOKBACK = GBL.N_SAMPLES - 1;
        }

        public static int LookbackStart() => GBL.N_SAMPLES - N_LOOKBACK;
    }
}