using System;
using MathNet.Numerics.Random;

namespace Engine.Random
{
    public static class DiceUtil
    {
        /// <summary>
        /// Rolls a number of dice with a given number of sides
        /// </summary>
        /// <param name="numDice"></param>
        /// <param name="diceSides"></param>
        /// <returns></returns>
        public static int Roll(int numDice, int diceSides)
        {
            if(numDice <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numDice), numDice, "must be a positive integer");
            }
            if(diceSides <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(diceSides), diceSides, "must be a positive integer");
            }

            int accumulator = 0;
            for(int i = 0; i < numDice; i++)
            {
                accumulator += RollOne(diceSides);
            }
            return accumulator;
        }

        /// <summary>
        /// Rolls a number of dice with a given number of sides, and takes the highest or lowest of all rolls.
        /// </summary>
        /// <param name="advantage">Determines how many dice are rolled. Positive advantage will take the highest value rolled, negative advantage will take the lowest. A value of 0 will be equivalent to calling <see cref="RollOne(diceSides)"/></param>
        /// <param name="diceSides">Number of sides on dice to roll</param>
        /// <returns>A value between 1 (inclusive) and the given number of sides on the dice (inclusive)</returns>
        public static int RollAdvantage(int advantage, int diceSides)
        {
            int best = (advantage >= 0) ? 1 : diceSides;

            for(int i = 0; i < Math.Abs(advantage) + 1; i++)
            {
                int value = RollOne(diceSides);
                if(advantage < 0)
                {
                    best = Math.Min(best, value);
                }
                else
                {
                    best = Math.Max(best, value);
                }
            }

            return best;
        }

        /// <summary>
        /// Rolls one fair dice with a given number of sides
        /// </summary>
        /// <param name="diceSides">Number of sides on dice to roll</param>
        /// <returns>A value between 1 (inclusive) and the given number of sides on the dice (inclusive)</returns>
        public static int RollOne(int diceSides)
        {
            return RandomUtil.Random.Next(1, diceSides+1);
        }
    }
}