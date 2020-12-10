using Leap;
using System;


namespace Global {
    public static class GBL {

        public static volatile bool      PLAY = false;          // Play playback state
        public static volatile bool      STOP = true;           // Stop playback state
        public static volatile bool      RECORD = false;        // Recording state
        public static volatile bool      DOG_FRIENDLY = false;  // Ultrasonic state
        public static volatile bool     CUSTOM_MODE = false;    // User customized settings

        public static int       N_POLLING_TIME = 20;    // Miliseconds
        public static int       N_SAMPLES = 10;         // Samples to track
        public static int       N_LOOKBACK = 9;         // Samples to start deceleration timing from

        public static float     UH_INTENSITY = 1.0f;    // Index 0-1
        public static float     UH_FREQUENCY = 150.0f;  // Hz
        public static int       UH_TIME     = 10;        // Centiseconds

        public static Vector    GES_POS_RANGE = new Vector{
            x = 100,
            y = 100,
            z = 100
        };
    }
}