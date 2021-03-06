using System;
using Xunit;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;

using Engine;
using Engine.Parsers;
using Engine.Parsers.Grammar;
using Engine.Parsers.Grammar.Visitors;
using Engine.Parsers.Generated.Grammar;
using System.Diagnostics;
using Common.Models;

namespace EngineTest.Grammar
{
    public class ParserTest
    {
        private GrammarParseResult Parse(string text)
        {
            AntlrInputStream inputStream = new AntlrInputStream(text);
            GrammarLexer grammarLexer = new GrammarLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(grammarLexer);
            GrammarParser grammarParser = new GrammarParser(commonTokenStream);
    
            GrammarParser.StatementsContext context = grammarParser.statements();
            StatementsVisitor visitor = new StatementsVisitor(new TestRuleSet());
            GrammarParseResult result = visitor.Visit(context);
            
            return result;
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
            GrammarParseResult result = Parse(text);
    
            Assert.True(result.IsSuccessful);
            Console.WriteLine(result.Output);
            Assert.Equal(expectedValue, result.Value);
        }
        

        [Theory]
        [InlineData("10d1", 10, 10)]
        [InlineData("10d1 - 4d1 + 3d1", 9, 9)]
        [InlineData("d20", 1, 20)]
        [InlineData("4d20", 4, 80)]
        [InlineData("!d20", 1, 20)]
        [InlineData("~d20", 1, 20)]
        [InlineData("~!!~!~~!!d20", 1, 20)]
        public void TestRoll(string text, int expectedLow, int expectedHigh)
        {
            GrammarParseResult result = Parse(text);
    
            //Just test it once. These tests are mainly to make sure it parses correctly
            Assert.True(result.IsSuccessful);
            Console.WriteLine(result.Output);
            Assert.InRange(result.Value, expectedLow, expectedHigh);
        }

        
        [Theory]
        [InlineData("d20+d20")]
        [InlineData("d20+!d20")]
        [InlineData("d20+!d20")]
        [InlineData("!d20")]
        [InlineData("2d3d4d5")]
        [InlineData("(2+2d4)d5 + 18")]
        public void TestComplexExpression(string text)
        {
            GrammarParseResult result = Parse(text);
    
            //Just test it once. These tests are mainly to make sure it parses correctly
            Assert.True(result.IsSuccessful);
            Console.WriteLine(result.Output);
            Console.WriteLine(result.Value);
        }

        
        [Theory]
        [InlineData("4 & 5", 2)]
        [InlineData("5d5+23/3:test & 53-22 & 21", 3)]
        public void TestMultiStatement(string text, int expectedStatements)
        {
            GrammarParseResult result = Parse(text);
    
            Assert.True(result.IsSuccessful);
            Assert.Equal(expectedStatements, result.Children.Count);
        }

        
        
        [Fact]
        public void TestStatementLabel()
        {
            string label = "This is a label";
            string text = $"5d10 + 2 : {label}";
            GrammarParseResult result = Parse(text);
    
            Assert.True(result.IsSuccessful);
            Assert.Equal(label, result.Label);
        }
    }
}