using LumeraDX_Calc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LumeraDX_Calc.Tests.Models
{
    [TestClass]
    public class MathOperationTests
    {
        [TestMethod]
        public void GIVEN_func_is_possible_THEN_perform_returns_success_result()
        {
            MathOperation mathOperation = new MathOperation(
                (i, j) => i + j, "somestring");

            var result = mathOperation.Perform(1, 2);

            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void GIVEN_func_causes_divide_by_zero_THEN_perform_returns_failure_result()
        {
            MathOperation mathOperation = new MathOperation(
                (i, j) => i / 0, "somestring");

            var result = mathOperation.Perform(1, 2);

            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void GIVEN_func_causes_other_math_exception_THEN_exception_thrown()
        {
            MathOperation mathOperation = new MathOperation(
                (i, j) => throw new NotFiniteNumberException(), "somestring");

            var result = mathOperation.Perform(1, 2);
            
        }
    }
}
