using System;
using LumeraDX_Calc.Models;
using LumeraDX_Calc.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LumeraDX_Calc.Tests.Services
{
    [TestClass]
    public class CalculatorTests
    {
        Calculator _subject;
        Mock<IOperationGetter> _mockOpGetter;

        [TestInitialize]
        public void Setup()
        {
            _mockOpGetter = new Mock<IOperationGetter>();

            _subject = new Calculator(_mockOpGetter.Object);
        }

        [TestMethod]
        public void GIVEN_defined_calculation_THEN_result_success_is_true()
        {
            SetupOpGetterReturnsAdd();
            var result = _subject.Calculate("AnySymbol", 1, 1);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void GIVEN_defined_calculation_THEN_result_is_correct()
        {
            SetupOpGetterReturnsAdd();
            var result = _subject.Calculate("AnySymbol", 1, 1);
            Assert.AreEqual(2, result.Value);
        }

        [TestMethod]
        public void GIVEN_undefined_calculation_THEN_result_success_is_false()
        {
            SetupOpGetterReturnsDivide();
            var result = _subject.Calculate("AnySymbol", 1, 0);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void GIVEN_undefined_calculation_THEN_result_exception_is_not_null()
        {
            SetupOpGetterReturnsDivide();
            var result = _subject.Calculate("AnySymbol", 1, 0);
            Assert.IsNotNull(result.Exception);
        }

        private void SetupOpGetterReturnsAdd()
        {
            _mockOpGetter.Setup(opg => opg.GetOperation(It.IsAny<string>())).Returns(MathOperation.Add);
        }

        private void SetupOpGetterReturnsDivide()
        {
            _mockOpGetter.Setup(opg => opg.GetOperation(It.IsAny<string>())).Returns(MathOperation.Divide);
        }
    }
}
