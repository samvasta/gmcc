using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Common.Models
{
    public struct DiceResult
    {
        public int NumDice;
        public int DiceSides;
        public List<int> Values;
        public bool IsCriticalSuccess;
        public bool IsCriticalFailure;
        public int Modifier;
        public int Total;

        public DiceResult(int numDice, int diceSides, List<int> values, bool isCriticalSuccess, bool isCriticalFailure, int modifier)
        {
            if(numDice != values.Count){
                throw new ArgumentException($"Length of {nameof(values)} must be equal to {nameof(numDice)}.");
            }

            NumDice = numDice;
            DiceSides = diceSides;
            Values = values;
            IsCriticalSuccess = isCriticalSuccess;
            IsCriticalFailure = isCriticalFailure;
            Modifier = modifier;

            if(Modifier == 0)
            {
                Total = Values.Sum();
            }
            else if(Modifier < 0)
            {
                Total = Values.Min();
            }
            else
            {
                Total = Values.Max();
            }
            
        }

        public DiceResult(int diceSides, int value)
        {
            NumDice = 1;
            DiceSides = diceSides;
            Values = new List<int>() { value };
            IsCriticalFailure = value == 1;
            IsCriticalSuccess = value == diceSides;
            Modifier = 0;

            Total = value;
        }

        public static DiceResult operator +(DiceResult x, DiceResult y)
        {
            List<int> values = new List<int>(x.NumDice + y.NumDice);
            values.AddRange(x.Values);
            values.AddRange(y.Values);

            bool isCriticalFailure = x.IsCriticalFailure && y.IsCriticalFailure;
            bool isCriticalSuccess = x.IsCriticalSuccess && y.IsCriticalSuccess;

            return new DiceResult(  x.NumDice + y.NumDice,
                                    x.DiceSides,
                                    values,
                                    isCriticalSuccess,
                                    isCriticalFailure,
                                    x.Modifier + y.Modifier);
        }
        
        public static implicit operator int(DiceResult x)
        {
            return x.Total;
        }

        /// <summary>
        /// Returns the DiceResult with the least total. First in list wins ties
        /// </summary>
        public static DiceResult MinTotal(params DiceResult[] results)
        {
            if(results.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            DiceResult min = results[0];

            for(int i = 1; i < results.Length; i++)
            {
                if(results[i].Total < min.Total)
                {
                    min = results[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Returns the DiceResult with the greatest total. First in list wins ties
        /// </summary>
        public static DiceResult MaxTotal(params DiceResult[] results)
        {
            if(results.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            DiceResult min = results[0];

            for(int i = 1; i < results.Length; i++)
            {
                if(results[i].Total > min.Total)
                {
                    min = results[i];
                }
            }
            
            return min;
        }
    }
}