using System;
using System.Collections.Generic;

namespace Engine.Parsers.Grammar
{
    public class GrammarParseResult
    {
        public enum BoolCombine
        {
            Or = 0,
            And = 1,
        }

        public enum ArithCombine
        {
            Ignore = -1,
            Add = 0,
            Subtract = 1,
            Multiply = 2,
            Divide = 3,
            Pow = 4,
            Modulus = 5
        }

        public enum StrCombine
        {
            Ignore = -1,
            Append = 0,
            Prepend = 1,
            LeftOnly = 2,
            RightOnly = 3
        }

        public static GrammarParseResult Unsuccessful(string rawText)
        {
            return new GrammarParseResult(String.Empty) { RawText = rawText, IsSuccessful = false, Value = -1, Output = "Operation failed" };
        }


        public string Label { get; set; } = String.Empty;
        public string EvaluatedText { get; set; } = String.Empty;
        public string RawText { get; set; } = String.Empty;
        public bool IsSuccessful { get; set; } = true;

        public int Value { get; set; } = 0;

        public string Output { get; set; } = String.Empty;

        public List<GrammarParseResult> Children { get; }

        public GrammarParseResult(string rawText)
        {
            RawText = rawText;
            Children = new List<GrammarParseResult>();
        }
        public GrammarParseResult(string rawText, params GrammarParseResult[] children)
            : this(rawText)
        {
            Children = new List<GrammarParseResult>(children);
        }


        public static GrammarParseResult Combine(string rawText, GrammarParseResult x, GrammarParseResult y, BoolCombine isSuccessfulCombine = BoolCombine.Or, ArithCombine valueCombine = ArithCombine.Add, StrCombine outputCombine = StrCombine.Ignore)
        {
            GrammarParseResult combined = new GrammarParseResult(rawText);
            combined.IsSuccessful = CombineSuccessful(x.IsSuccessful, y.IsSuccessful, isSuccessfulCombine);
            combined.Value = CombineValue(x.Value, y.Value, valueCombine);
            combined.Output = CombineOutput(x.Output, y.Output, outputCombine);

            combined.Children.Add(x);
            combined.Children.Add(y);

            return combined;
        }

        private static string CombineOutput(string outputX, string outputY, StrCombine combine)
        {
            switch(combine)
            {
                case StrCombine.Ignore:
                    return String.Empty;

                case StrCombine.Append:
                return String.Concat(outputX, Environment.NewLine, outputY);

                case StrCombine.Prepend:
                    return String.Concat(outputY, Environment.NewLine, outputX);

                case StrCombine.LeftOnly:
                    return outputX;

                case StrCombine.RightOnly:
                    return outputY;

                default:
                    throw new ArgumentException($"No combine logic defined for combine type: {Enum.GetName(typeof(StrCombine), combine)}");
            }
        }

        private static int CombineValue(int valueX, int valueY, ArithCombine combine)
        {
            switch(combine)
            {
                case ArithCombine.Ignore:
                    //Do nothing
                    return 0;
                case ArithCombine.Add:
                    return valueX + valueY;

                case ArithCombine.Subtract:
                    return valueX - valueY;

                case ArithCombine.Multiply:
                    return valueX * valueY;

                case ArithCombine.Divide:
                    return valueX / valueY;

                case ArithCombine.Pow:
                    return (int)Math.Pow(valueX, valueY);

                case ArithCombine.Modulus:
                    return valueX % valueY;

                default:
                    throw new ArgumentException($"No combine logic defined for combine type: {Enum.GetName(typeof(ArithCombine), combine)}");
            }
        }

        private static bool CombineSuccessful(bool isSuccessfulX, bool isSuccessfulY, BoolCombine combine)
        {
            switch(combine)
            {
                case BoolCombine.Or:
                    return isSuccessfulX || isSuccessfulY;
                case BoolCombine.And:
                    return isSuccessfulX && isSuccessfulY;
                default:
                    throw new ArgumentException($"No combine logic defined for combine type: {Enum.GetName(typeof(BoolCombine), combine)}");
            }
        }
    }
}