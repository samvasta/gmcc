using System;
using System.Linq;
using Common.Models;
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
        public static DiceResult Roll(int numDice, int diceSides)
        {
            if(numDice <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numDice), numDice, "must be a positive integer");
            }
            if(diceSides <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(diceSides), diceSides, "must be a positive integer");
            }

            System.Diagnostics.Debug.WriteLine($"DiceUtil is rolling {numDice}d{diceSides}");

            DiceResult result = RollOne(diceSides);
            for(int i = 1; i < numDice; i++)
            {
                result += RollOne(diceSides);
            }
            return result;
        }

        /// <summary>
        /// Rolls a number of dice with a given number of sides, and takes the highest or lowest of all rolls.
        /// </summary>
        /// <param name="advantage">Determines how many dice are rolled. Positive advantage will take the highest value rolled, negative advantage will take the lowest. A value of 0 will be equivalent to calling <see cref="RollOne(diceSides)"/></param>
        /// <param name="diceSides">Number of sides on dice to roll</param>
        /// <returns>A value between 1 (inclusive) and the given number of sides on the dice (inclusive)</returns>
        public static DiceResult RollAdvantage(int advantage, int diceSides)
        {
            DiceResult best = RollOne(diceSides);

            for(int i = 1; i < Math.Abs(advantage) + 1; i++)
            {
                DiceResult value = RollOne(diceSides);
                best.Values.Add(value);
            }

            if(advantage < 0)
            {
                best.Total = best.Values.Min();
            }
            else
            {
                best.Total = best.Values.Max();
            }

            return best;
        }

        /// <summary>
        /// Rolls one fair dice with a given number of sides
        /// </summary>
        /// <param name="diceSides">Number of sides on dice to roll</param>
        /// <returns>A value between 1 (inclusive) and the given number of sides on the dice (inclusive)</returns>
        public static DiceResult RollOne(int diceSides)
        {
            return new DiceResult(diceSides, RandomUtil.Random.Next(1, diceSides+1));
        }
    }
}