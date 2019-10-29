using LumeraDX_Calc.Models;
using System.Linq;

namespace LumeraDX_Calc.Services
{
    public interface ICalculator
    {
        Result<int> Calculate(string operation, int operandOne, int operandTwo);
    }

    public class Calculator : ICalculator
    {
        private IOperationGetter _operationGetter;

        public Calculator()
        {
            _operationGetter = new OperationGetter();
        }

        public Calculator(IOperationGetter operationGetter)
        {
            _operationGetter = operationGetter;
        }

        public Result<int> Calculate(string operationSymbol, int operandOne, int operandTwo)
        {
            return _operationGetter.GetOperation(operationSymbol)
                .Perform(operandOne, operandTwo);
        }
    }

    public interface IOperationGetter
    {
        MathOperation GetOperation(string operationSymbol);
    }

    public class OperationGetter : IOperationGetter
    {
        public MathOperation GetOperation(string operationSymbol)
        {
            return MathOperation.AvailableOperations.Single(op => operationSymbol == op.Index);
        }
    }
}