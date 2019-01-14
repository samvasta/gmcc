using System;
using System.Collections.Generic;
using System.Diagnostics;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Common.Interfaces;
using Engine.Parsers.Generated.Grammar;
using static Engine.Parsers.Generated.Grammar.GrammarParser;
using static Common.Models.GrammarParseResult;
using Common.Models;

namespace Engine.Parsers.Grammar.Visitors
{
    public class StatementsVisitor : GrammarBaseVisitor<GrammarParseResult>
    {
        protected readonly ExpressionVisitor _expressionVisitor = new ExpressionVisitor();

        protected readonly IRuleSet _ruleSet;

        public StatementsVisitor(IRuleSet ruleSet)
        {
            _ruleSet = ruleSet;
        }

        public override GrammarParseResult VisitStatements(StatementsContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
            }

            Debug.WriteLine($"VisitStatements \"{context.GetText()}\"");

            StatementContext[] statements = context.statement();

            if(statements.Length == 1)
            {
                return VisitStatement(statements[0]);
            }

            GrammarParseResult result = new GrammarParseResult(context.GetText());
            foreach(StatementContext ctx in statements)
            {
                result.Children.Add(VisitStatement(ctx));
            }

            return result;
        }

        public override GrammarParseResult VisitStatement(StatementContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
            }

            Debug.WriteLine($"VisitStatement \"{context.GetText()}\"");
            
            string labelStr = context.label()?.STRING()?.GetText();

            //Successful if any of the 3 possible productions are successful
            var expression = context.expression();
            if(expression != null)
            {
                GrammarParseResult result = _expressionVisitor.VisitExpression(expression);
                if(result.IsSuccessful)
                {
                    result.Label = labelStr;
                    return result;
                }
            }
            
            var command = context.command();
            if(command != null)
            {
                GrammarParseResult result = VisitCommand(command);
                if(result.IsSuccessful)
                {
                    result.Label = labelStr;
                    return result;
                }
            }
            
            var action = context.action();
            if(action != null)
            {
                GrammarParseResult result = VisitAction(action);
                if(result.IsSuccessful)
                {
                    result.Label = labelStr;
                    return result;
                }
            }

            return GrammarParseResult.Unsuccessful(context.GetText());
        }
    }
}