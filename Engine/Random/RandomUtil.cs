using System;
using MathNet.Numerics.Random;

namespace Engine.Random
{
    public static class RandomUtil
    {

        static RandomUtil()
        {
            //Setting seed with generate the random
            SetSeed(Environment.TickCount);
        }

        private static int _seed;
        public static void SetSeed(int seed)
        {
            _seed = seed;
            _random = new MersenneTwister(_seed, true);
        }
        
        private static MersenneTwister _random;
        public static MersenneTwister Random
        {
            get
            {
                if(_random == null)
                {
                    //Setting seed with generate the random
                    SetSeed(Environment.TickCount);
                }
                return _random;
            }
        }
    }
}