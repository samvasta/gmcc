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
    public class StatementsVisitor : GrammarBaseVisitor<GrammarParseResult>
    {
        protected readonly ExpressionVisitor _expressionVisitor = new ExpressionVisitor();

        public override GrammarParseResult VisitStatements(StatementsContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Debug.WriteLine($"VisitStatements \"{context.GetText()}\"");

            //Only successful if all statements are successful
            GrammarParseResult result = new GrammarParseResult();

            foreach(StatementContext ctx in context.statement())
            {
                result.Combine(VisitStatement(ctx), isSuccessfulCombine: BoolCombine.And);
            }

            return result;
        }

        public override GrammarParseResult VisitStatement(StatementContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Debug.WriteLine($"VisitStatement \"{context.GetText()}\"");

            //Successful if any of the 3 possible productions are successful
            GrammarParseResult result = _expressionVisitor.VisitExpression(context.expression());
            if(result.IsSuccessful)
            {
                return result;
            }
            result = VisitCommand(context.command());
            if(result.IsSuccessful)
            {
                return result;
            }
            result = VisitAction(context.action());
            if(result.IsSuccessful)
            {
                return result;
            }

            return GrammarParseResult.UNSUCCESSFUL;
        }
    }
}