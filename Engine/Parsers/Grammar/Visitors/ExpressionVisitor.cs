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
    public class ExpressionVisitor : GrammarBaseVisitor<GrammarParseResult>
    {
        protected readonly ValueVisitor _valueVisitor = new ValueVisitor();
        

        public virtual GrammarParseResult VisitExpression(ExpressionContext context)
        {
            Debug.WriteLine($"Determining Type of expression \"{context.GetText()}\"");
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
            throw new ArgumentException($"No logic defined for expression of this type: {context.GetType().Name}");
        }

        
        public override GrammarParseResult VisitPowExpr(PowExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Debug.WriteLine($"VisitPowExpression \"{context.GetText()}\"");

            return VisitArithmeticExpr(context.lhs, context.rhs, context.op);
        }

        public override GrammarParseResult VisitAdditiveExpr(AdditiveExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Debug.WriteLine($"VisitAddExpression \"{context.GetText()}\"");

            return VisitArithmeticExpr(context.lhs, context.rhs, context.op);
        }

        public override GrammarParseResult VisitMultiplicationExpr(MultiplicationExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Debug.WriteLine($"VisitMulExpression \"{context.GetText()}\"");

            return VisitArithmeticExpr(context.lhs, context.rhs, context.op);
        }

        public override GrammarParseResult VisitUnaryMinusExpr(UnaryMinusExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Debug.WriteLine($"VisitUnaryMinusExpression \"{context.GetText()}\"");

            ExpressionContext lhsValue = context.expression();
            GrammarParseResult result = Visit(lhsValue);

            result.Value *= -1;

            return result;
        }

        public override GrammarParseResult VisitParenExpr(ParenExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }

            Debug.WriteLine($"VisitParenExpr \"{context.GetText()}\"");
            
            return VisitExpression(context.expression());
        }


        public override GrammarParseResult VisitValueExpr(ValueExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.UNSUCCESSFUL;
            }
            Debug.WriteLine($"VisitValueExpr \"{context.GetText()}\"");

            return _valueVisitor.VisitValue(context.value());
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
    }
}