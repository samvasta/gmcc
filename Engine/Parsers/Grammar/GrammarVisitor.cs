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

namespace Engine.Parsers.Grammar
{
    public class GrammarVisitor : GrammarBaseVisitor<GrammarParseResult>
    {
        public override GrammarParseResult VisitStatements(StatementsContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Console.WriteLine($"VisitStatements \"{context.GetText()}\"");

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

            Console.WriteLine($"VisitStatement \"{context.GetText()}\"");

            //Successful if any of the 3 possible productions are successful
            GrammarParseResult result = VisitExpression(context.expression());
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

        protected virtual GrammarParseResult VisitExpression(ExpressionContext context)
        {
            Console.WriteLine($"Determining Type of expression \"{context.GetText()}\"");
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }
            if(context is ParenExprContext parenExprContext)
            {
                return VisitExpression(parenExprContext.expression());
            }
            if(context is PowExprContext powExprContext)
            {
                return VisitPowExpr(powExprContext);
            }
            if(context is AdditiveExprContext addExprContext)
            {
                return VisitAdditiveExpr(addExprContext);
            }
            if(context is MultiplicationExprContext mulExprContext)
            {
                return VisitMultiplicationExpr(mulExprContext);
            }
            if(context is UnaryMinusExprContext unaryMinusExprContext)
            {
                return VisitUnaryMinusExpr(unaryMinusExprContext);
            }
            if(context is ValueExprContext valueExprContext)
            {
                return VisitValueExpr(valueExprContext);
            }
            return Visit(context);
            // throw new ArgumentException($"No logic defined for expression of this type: {context.GetType().Name}");
        }

        public override GrammarParseResult VisitPowExpr(PowExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Console.WriteLine($"VisitPowExpression \"{context.GetText()}\"");

            return VisitArithmeticExpr(context.lhs, context.rhs, context.op);
        }

        public override GrammarParseResult VisitAdditiveExpr(AdditiveExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Console.WriteLine($"VisitAddExpression \"{context.GetText()}\"");

            return VisitArithmeticExpr(context.lhs, context.rhs, context.op);
        }

        public override GrammarParseResult VisitMultiplicationExpr(MultiplicationExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Console.WriteLine($"VisitMulExpression \"{context.GetText()}\"");

            return VisitArithmeticExpr(context.lhs, context.rhs, context.op);
        }

        public override GrammarParseResult VisitUnaryMinusExpr(UnaryMinusExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Console.WriteLine($"VisitUnaryMinusExpression \"{context.GetText()}\"");

            ExpressionContext lhsValue = context.expression();
            GrammarParseResult result = Visit(lhsValue);

            result.Value *= -1;

            return result;
        }

        

        protected GrammarParseResult VisitArithmeticExpr(ExpressionContext lhs, ExpressionContext rhs, IToken op)
        {
            Console.WriteLine($"Visit Arithmetic Expression lhs=\"{lhs.GetText()}\", rhs=\"{lhs.GetText()}\", op=\"{op.Text}\"");
            GrammarParseResult result = VisitExpression(lhs);

            GrammarParseResult rhsResult = VisitExpression(rhs);

            result.Combine(rhsResult, BoolCombine.And, GetArithCombine(op.Text));

            return result;
        }

        private ArithCombine GetArithCombine(string op)
        {
            switch(op)
            {
                case "+":
                    return ArithCombine.Add;
                case "-":
                    return ArithCombine.Subtract;
                case "*":
                    return ArithCombine.Multiply;
                case "/":
                    return ArithCombine.Divide;
                case "^":
                    return ArithCombine.Pow;
                case "%":
                    return ArithCombine.Modulus;
            }

            Debug.WriteLine($"WARNING: No arithmetic symbol could not be parsed! ({op})");

            return ArithCombine.Ignore;
        }

        public override GrammarParseResult VisitValueExpr(ValueExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }
            Console.WriteLine($"VisitValueExpr \"{context.GetText()}\"");

            return VisitValue(context.value());
        }

        protected virtual GrammarParseResult VisitValue(ValueContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }
            Console.WriteLine($"Determining Type of value \"{context.GetText()}\"");
            
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

            Console.WriteLine($"VisitNumberValue \"{context.GetText()}\"");
            int value = int.Parse(context.GetText());

            return new GrammarParseResult() { Value = value };
        }

        public override GrammarParseResult VisitParenExpr(ParenExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Console.WriteLine($"VisitParenExpr \"{context.GetText()}\"");
            
            return VisitExpression(context.expression());
        }

        public override GrammarParseResult VisitRollValue(RollValueContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }
            Console.WriteLine($"VisitRollValue \"{context.GetText()}\"");

            throw new NotImplementedException();
        }

        public override GrammarParseResult VisitRoll(RollContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Console.WriteLine($"VisitRoll \"{context.GetText()}\"");
            return GrammarParseResult.UNSUCCESSFUL;
        }

        public override GrammarParseResult VisitModifier(ModifierContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Console.WriteLine($"VisitModifier \"{context.GetText()}\"");
            return GrammarParseResult.UNSUCCESSFUL;
        }

        public override GrammarParseResult VisitCommand(CommandContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Console.WriteLine($"VisitCommand \"{context.GetText()}\"");
            return GrammarParseResult.UNSUCCESSFUL;
        }

        public override GrammarParseResult VisitAction(ActionContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Console.WriteLine($"VisitAction \"{context.GetText()}\"");
            return GrammarParseResult.UNSUCCESSFUL;
        }
    }
}