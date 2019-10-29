using System;
using System.Collections.Generic;
using System.Linq;

namespace LumeraDX_Calc.Models
{
    public class MathOperation
    {
        public const string AddSymbol = "+";
        public const string SubtractSymbol = "-";
        public const string MultiplySymbol = "*";
        public const string DivideSymbol = "/";

        public static readonly MathOperation Add = new MathOperation((operandOne, operandTwo) => operandOne + operandTwo, AddSymbol);
        public static readonly MathOperation Substract = new MathOperation((operandOne, operandTwo) => operandOne - operandTwo, SubtractSymbol);
        public static readonly MathOperation Multiply = new MathOperation((operandOne, operandTwo) => operandOne * operandTwo, MultiplySymbol);
        public static readonly MathOperation Divide = new MathOperation((operandOne, operandTwo) => operandOne / operandTwo, DivideSymbol);

        public static List<MathOperation> AvailableOperations = new List<MathOperation> { Add, Substract, Multiply, Divide };

        private Func<int, int, int> _operation;
        public string Index { get; }
        public MathOperation(Func<int, int, int> operation, string index)
        {
            _operation = operation;
            Index = index;
        }

        public Result<int> Perform(int operandOne, int operandTwo)
        {
            try
            {
                return new Result<int>(_operation(operandOne, operandTwo));
            }
            catch (DivideByZeroException ex)
            {
                return new Result<int>(0, ex);
            }
        }
    }
}