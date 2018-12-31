using System;

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
            Overwrite = 2,
        }

        public static readonly GrammarParseResult UNSUCCESSFUL = new GrammarParseResult() { IsSuccessful = false, Value = -1, Output = "Operation failed" };

        public bool IsSuccessful { get; set; } = true;

        public int Value { get; set; } = 0;

        public string Output { get; set; } = String.Empty;

        public void Combine(GrammarParseResult result, BoolCombine isSuccessfulCombine = BoolCombine.Or, ArithCombine valueCombine = ArithCombine.Add, StrCombine outputCombine = StrCombine.Append)
        {
            CombineSuccessful(result.IsSuccessful, isSuccessfulCombine);
            CombineValue(result.Value, valueCombine);
            CombineOutput(result.Output, outputCombine);
        }

        private void CombineOutput(string otherOutput, StrCombine combine)
        {
            switch(combine)
            {
                case StrCombine.Ignore:
                    //Do nothing
                    break;
                case StrCombine.Append:
                    Output += Environment.NewLine + otherOutput;
                    break;
                case StrCombine.Prepend:
                    Output = otherOutput + Environment.NewLine + Output;
                    break;
                case StrCombine.Overwrite:
                    Output = otherOutput;
                    break;
                default:
                    throw new ArgumentException($"No combine logic defined for combine type: {Enum.GetName(typeof(StrCombine), combine)}");
            }
            Output = Output.Trim();
        }

        private void CombineValue(int otherValue, ArithCombine combine)
        {
            switch(combine)
            {
                case ArithCombine.Ignore:
                    //Do nothing
                    return;
                case ArithCombine.Add:
                    Value += otherValue;
                    return;
                case ArithCombine.Subtract:
                    Value -= otherValue;
                    return;
                case ArithCombine.Multiply:
                    Value *= otherValue;
                    return;
                case ArithCombine.Divide:
                    Value /= otherValue;
                    return;
                case ArithCombine.Pow:
                    Value = (int)Math.Pow(Value, otherValue);
                    return;
                case ArithCombine.Modulus:
                    Value = Value % otherValue;
                    return;
                default:
                    throw new ArgumentException($"No combine logic defined for combine type: {Enum.GetName(typeof(ArithCombine), combine)}");
            }
        }

        private void CombineSuccessful(bool otherIsSuccessful, BoolCombine combine)
        {
            switch(combine)
            {
                case BoolCombine.Or:
                    IsSuccessful |= otherIsSuccessful;
                    return;
                case BoolCombine.And:
                    IsSuccessful &= otherIsSuccessful;
                    return;
                default:
                    throw new ArgumentException($"No combine logic defined for combine type: {Enum.GetName(typeof(BoolCombine), combine)}");
            }
        }
    }
}