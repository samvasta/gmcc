using System;
using Xunit;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;

using Engine.Parsers;
using Engine.Parsers.Grammer;

namespace EngineTest
{
    public class ParserTest
    {
        private GrammerParser Setup(string text)
        {
            AntlrInputStream inputStream = new AntlrInputStream(text);
            GrammerLexer grammerLexer = new GrammerLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(grammerLexer);
            GrammerParser grammerParser = new GrammerParser(commonTokenStream);
    
            return grammerParser;   
        }
    
        [Fact]
        public void TestChat()
        {
            GrammerParser parser = Setup("john says \"hello\" \n michael says \"world\" \n");
    
            GrammerParser.ChatContext context = parser.chat();
            GrammerVisitor visitor = new GrammerVisitor();
            visitor.Visit(context);
    
            Assert.Equal(2, visitor.Lines.Count);
        }
        
        [Fact]
        public void TestLine()
        {
            GrammerParser parser = Setup("john says \"hello\" \n");
    
            GrammerParser.LineContext context = parser.line();
            GrammerVisitor visitor = new GrammerVisitor();
            GrammerLine line = (GrammerLine) visitor.VisitLine(context);            
            
            Assert.Equal("john", line.Person);
            Assert.Equal("hello", line.Text);
        }
    
        [Fact]
        public void TestWrongLine()
        {
            GrammerParser parser = Setup("john sayan \"hello\" \n");
    
            var context = parser.line();
            
            Assert.IsType<GrammerParser.LineContext>(context);
            Assert.Equal("john", context.name().GetText());
            Assert.Null(context.SAYS());
            Assert.Equal("johnsayan\"hello\"\n", context.GetText());
        }      
    }
}