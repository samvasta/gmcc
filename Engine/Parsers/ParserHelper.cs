using Antlr4.Runtime;
using Engine.Parsers.Generated.Grammar;
using Engine.Parsers.Grammar;
using Engine.Parsers.Grammar.Visitors;

namespace Engine.Parsers
{
    public static class ParserHelper
    {
        public static GrammarParseResult Evaluate(string text)
        {
            AntlrInputStream inputStream = new AntlrInputStream(text);
            GrammarLexer grammarLexer = new GrammarLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(grammarLexer);
            GrammarParser grammarParser = new GrammarParser(commonTokenStream);
            
            GrammarParser.StatementsContext context = grammarParser.statements();
            StatementsVisitor visitor = new StatementsVisitor();
            GrammarParseResult result = visitor.Visit(context);

            return result;
        }
    }
}