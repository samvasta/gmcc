using System;
using Xunit;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;

using Engine;
using Engine.Parsers;
using Engine.Parsers.Grammar;
using Engine.Parsers.Generated.Grammar;

namespace EngineTest
{
    public class ParserTest
    {
        private GrammarParser Setup(string text)
        {
            AntlrInputStream inputStream = new AntlrInputStream(text);
            GrammarLexer grammarLexer = new GrammarLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(grammarLexer);
            GrammarParser grammarParser = new GrammarParser(commonTokenStream);
    
            return grammarParser;   
        }
        
        [Theory]
        [InlineData("10 + 10", 20)]
        [InlineData("2 + (3 + 7)", 12)]
        [InlineData("10 - 9", 1)]
        [InlineData("4 * 4", 16)]
        [InlineData("20 / 4", 5)]
        [InlineData("2^2", 4)]
        [InlineData("2^2+1", 5)]
        [InlineData("2^(2+1)", 8)]
        [InlineData("10%2", 0)]
        [InlineData("10%(2*2)", 2)]
        [InlineData("-10", -10)]
        [InlineData("10-10", 0)]
        [InlineData("10--10", 20)]
        [InlineData("10*4-2*(4^2/4)/2+9", 45)]
        [InlineData("-10/(20/2^2*5/5)*8-2", -18)]
        public void TestArithmetic(string text, int expectedValue)
        {
            GrammarParser parser = Setup(text);
    
            GrammarParser.StatementsContext context = parser.statements();
            GrammarVisitor visitor = new GrammarVisitor();
            GrammarParseResult result = visitor.Visit(context);
    
            Assert.True(result.IsSuccessful);
            Console.WriteLine(result.Output);
            Assert.Equal(expectedValue, result.Value);
        }
        
    }
}