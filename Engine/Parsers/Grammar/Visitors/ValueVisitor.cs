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
    public class ValueVisitor : GrammarBaseVisitor<GrammarParseResult>
    {
        protected readonly RollVisitor _rollVisitor = new RollVisitor();


        public virtual GrammarParseResult VisitValue(ValueContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }
            Debug.WriteLine($"Determining Type of value \"{context.GetText()}\"");
            
            if(context is NumberValueContext numberValueContext)
            {
                return VisitNumberValue(numberValueContext);
            }
            if(context is RollValueContext rollValueContext)
            {
                return VisitRollValue(rollValueContext);
            }
            throw new ArgumentException($"No logic defined for value of this type: {context.GetType().Name}");
        }

        public override GrammarParseResult VisitNumberValue(NumberValueContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Debug.WriteLine($"VisitNumberValue \"{context.GetText()}\"");
            int value = int.Parse(context.GetText());

            return new GrammarParseResult() { Value = value };
        }

        public override GrammarParseResult VisitRollValue(RollValueContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }
            Debug.WriteLine($"VisitRollValue \"{context.GetText()}\"");

            return _rollVisitor.VisitRoll(context.roll());
        }
    }
}