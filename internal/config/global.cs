using Leap;
using System;


namespace Global {
    public static class GBL {

        public static volatile bool      PLAY = false;
        public static volatile bool      STOP = true;
        public static volatile bool      RECORD = false;
        public static volatile bool      dogMode = false;

        public static int       N_POLLING_MILISECONDS = 20;
        public static int       N_SAMPLES = 10;
        public static int       N_LOOKBACK = 9;

        public static float     UH_INTENSITY = 1.0f;
        public static float     UH_FREQUENCY = 200.0f;
        public static int       UH_TIME     = 50;

        public static Vector    GES_POS_RANGE = new Vector{
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