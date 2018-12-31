using System;
using System.Collections.Generic;
using System.Diagnostics;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Common.Models;
using Engine.Parsers.Generated.Grammar;
using Engine.Random;
using static Engine.Parsers.Generated.Grammar.GrammarParser;
using static Engine.Parsers.Grammar.GrammarParseResult;

namespace Engine.Parsers.Grammar.Visitors
{
    public class ExpressionVisitor : GrammarBaseVisitor<GrammarParseResult>
    {
        public virtual GrammarParseResult VisitExpression(ExpressionContext context)
        {
            Debug.WriteLine($"Determining Type of expression \"{context.GetText()}\"");
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
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
            if(context is NumberExprContext numberExprContext)
            {
                return VisitNumberExpr(numberExprContext);
            }
            if(context is ModifierRollContext modifierRollContext)
            {
                return VisitModifierRoll(modifierRollContext);
            }
            if(context is SumRollContext sumRollContext)
            {
                return VisitSumRoll(sumRollContext);
            }
            throw new ArgumentException($"No logic defined for expression of this type: {context.GetType().Name}");
        }

        
        public override GrammarParseResult VisitPowExpr(PowExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
            }

            Debug.WriteLine($"VisitPowExpression \"{context.GetText()}\"");

            return VisitArithmeticExpr(context.lhs, context.rhs, context.op);
        }

        public override GrammarParseResult VisitAdditiveExpr(AdditiveExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
            }

            Debug.WriteLine($"VisitAddExpression \"{context.GetText()}\"");

            return VisitArithmeticExpr(context.lhs, context.rhs, context.op);
        }

        public override GrammarParseResult VisitMultiplicationExpr(MultiplicationExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
            }

            Debug.WriteLine($"VisitMulExpression \"{context.GetText()}\"");

            return VisitArithmeticExpr(context.lhs, context.rhs, context.op);
        }

        public override GrammarParseResult VisitUnaryMinusExpr(UnaryMinusExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
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
                return GrammarParseResult.Unsuccessful(context.GetText());
            }

            Debug.WriteLine($"VisitParenExpr \"{context.GetText()}\"");
            
            return VisitExpression(context.expression());
        }


        public override GrammarParseResult VisitNumberExpr(NumberExprContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
            }
            Debug.WriteLine($"VisitNumberExpr \"{context.GetText()}\"");

            int value = int.Parse(context.GetText());

            return new GrammarParseResult(context.GetText()) { Value = value };
        }

        public override GrammarParseResult VisitModifierRoll(ModifierRollContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
            }

            Debug.WriteLine($"VisitModifierRoll \"{context.GetText()}\"");
            
            int numAdvantage = context.ADVANTAGE().Length - context.DISADVANTAGE().Length;
            GrammarParseResult childDiceSides = VisitExpression(context.expression());
            childDiceSides.Label = "Dice Sides";
            int diceSides = childDiceSides.Value;

            GrammarParseResult result = new GrammarParseResult(context.GetText());
            string advStr;
            if(numAdvantage == 0)
            {
                advStr = String.Empty;
            }
            else if(numAdvantage > 0)
            {
                advStr = "Highest of ";
            }
            else
            {
                advStr = "Lowest of ";
            }

            result.EvaluatedText = $"{advStr}{Math.Abs(numAdvantage)+1}d{diceSides}";
            result.Children.Add(childDiceSides);

            DiceResult diceResult = DiceUtil.RollAdvantage(numAdvantage, diceSides);
            result.Value = diceResult.Total;
            result.Output = String.Join(", ", diceResult.Values);

            return result;
        }

        public override GrammarParseResult VisitSumRoll(SumRollContext context)
        {
            if(context == null)
            {
                return GrammarParseResult.Unsuccessful(context.GetText());
            }

            Debug.WriteLine($"VisitSumRoll \"{context.GetText()}\"");
            
            GrammarParseResult childNumDice = VisitExpression(context.num);
            childNumDice.Label = "# Dice";
            GrammarParseResult childDiceSides = VisitExpression(context.sides);
            childDiceSides.Label = "Dice Sides";
            int numDice = childNumDice.Value;
            int diceSides = childDiceSides.Value;

            GrammarParseResult result = new GrammarParseResult(context.GetText());
            result.Children.Add(childNumDice);
            result.Children.Add(childDiceSides);

            result.EvaluatedText = $"{numDice}d{diceSides}";

            DiceResult diceResult = DiceUtil.Roll(numDice, diceSides);
            result.Value = diceResult.Total;
            result.Output = String.Join(", ", diceResult.Values);

            return result;
        }
        

        protected GrammarParseResult VisitArithmeticExpr(ExpressionContext lhs, ExpressionContext rhs, IToken op)
        {
            Console.WriteLine($"Visit Arithmetic Expression lhs=\"{lhs.GetText()}\", rhs=\"{lhs.GetText()}\", op=\"{op.Text}\"");
            GrammarParseResult lhsResult = VisitExpression(lhs);

            GrammarParseResult rhsResult = VisitExpression(rhs);

            string resultText = String.Concat(lhs.GetText(), op.Text, rhs.GetText());
            return GrammarParseResult.Combine(resultText, lhsResult, rhsResult, BoolCombine.And, GetArithCombine(op.Text));
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