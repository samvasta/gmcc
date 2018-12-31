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
    public class RollVisitor : GrammarBaseVisitor<GrammarParseResult>
    {
        public GrammarParseResult VisitRoll(RollContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }
            Debug.WriteLine($"Determining Type of roll \"{context.GetText()}\"");
            
            if(context is ModifierRollContext modifierRollContext)
            {
                return VisitModifierRoll(modifierRollContext);
            }
            if(context is SumRollContext sumRollContext)
            {
                return VisitSumRoll(sumRollContext);
            }
            throw new ArgumentException($"No logic defined for roll of this type: {context.GetType().Name}");
        }

        public override GrammarParseResult VisitModifierRoll(ModifierRollContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Debug.WriteLine($"VisitRoll \"{context.GetText()}\"");
            return GrammarParseResult.UNSUCCESSFUL;
        }

        public override GrammarParseResult VisitSumRoll(SumRollContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Debug.WriteLine($"VisitRoll \"{context.GetText()}\"");
            return GrammarParseResult.UNSUCCESSFUL;
        }
    }
}