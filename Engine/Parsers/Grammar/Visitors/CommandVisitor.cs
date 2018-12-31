using System;
using System.Collections.Generic;
using System.Diagnostics;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Engine.Parsers.Generated.Grammar;
using static Engine.Parsers.Generated.Grammar.GrammarParser;
using static Engine.Parsers.Grammar.GrammarParseResult;

namespace Engine.Parsers.Grammar.Visitors
{
    public class CommandVisitor : GrammarBaseVisitor<GrammarParseResult>
    {
        public override GrammarParseResult VisitCommand(CommandContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
            }

            Console.WriteLine($"VisitCommand \"{context.GetText()}\"");
            return GrammarParseResult.Unsuccessful(context.GetText());
        }

    }
}