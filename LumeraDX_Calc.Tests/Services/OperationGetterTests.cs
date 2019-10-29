using LumeraDX_Calc.Models;
using LumeraDX_Calc.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LumeraDX_Calc.Tests.Services
{
    [TestClass]
    public class OperationGetterTests
    {
        private OperationGetter _subject;

        [TestInitialize]
        public void Setup()
        {
            _subject = new OperationGetter();
        }

        [TestMethod]
        public void GIVEN_plus_symbol_THEN_operation_is_add()
        {
            Assert.AreEqual(MathOperation.Add, _subject.GetOperation("+"));     
        }

        [TestMethod]
        public void GIVEN_minus_symbol_THEN_operation_is_subtraction()
        {
            Assert.AreEqual(MathOperation.Substract, _subject.GetOperation("-"));
        }

        [TestMethod]
        public void GIVEN_star_symbol_THEN_operation_is_multiply()
        {
            Assert.AreEqual(MathOperation.Multiply, _subject.GetOperation("*"));
        }

        [TestMethod]
        public void GIVEN_star_symbol_THEN_operation_is_divide()
        {
            Assert.AreEqual(MathOperation.Divide, _subject.GetOperation("/"));
        }
    }
}
