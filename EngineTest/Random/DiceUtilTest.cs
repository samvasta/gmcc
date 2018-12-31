using System;
using Xunit;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;

using Engine.Random;


namespace EngineTest
{
    public class DiceUtilTest
    {
        
        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 20)]
        [InlineData(10, 20)]
        public void TestRoll(int numDice, int diceSides)
        {
            //Repeat 100 times to make sure nothing crazy is going on
            for(int i = 0; i < 100; i++)
            {
                int value = DiceUtil.Roll(numDice, diceSides);

                Assert.InRange(value, 1 * numDice, diceSides * numDice);
            }
        }

        
        [Fact]
        public void TestRollAdvantage()
        {
            int diceSides = 20;

            //1000 advantage should ensure the max (20) is returned
            int value = DiceUtil.RollAdvantage(1000, diceSides);

            Assert.Equal(diceSides, value);
        }
        
        [Fact]
        public void TestRollDisadvantage()
        {
            int diceSides = 20;

            //1000 disadvantage should ensure the min (1) is returned
            int value = DiceUtil.RollAdvantage(-1000, diceSides);

            Assert.Equal(1, value);
        }


        [Theory]
        [InlineData(-1, 20)]
        [InlineData(0, 20)]
        [InlineData(1, -20)]
        [InlineData(1, 0)]
        public void TestRollFailure(int numDice, int diceSides)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DiceUtil.Roll(numDice, diceSides));
        }
    }
}