using LumeraDX_Calc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumeraDX_Calc.Tests.Models
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void WHEN_success_THEN_onSuccess_is_executed()
        {
            var onSuccessExecuted = false;
            var onFailureExecuted = false;
            Result<object> result = new Result<object>(new object());

            result.Match(o => onSuccessExecuted = true, e => onFailureExecuted = true);

            Assert.IsTrue(onSuccessExecuted);
            Assert.IsFalse(onFailureExecuted);
        }

        [TestMethod]
        public void WHEN_failure_THEN_onFailure_is_executed()
        {
            var onSuccessExecuted = false;
            var onFailureExecuted = false;
            Result<object> result = new Result<object>(null, new Exception("Failure"));

            result.Match(o => onSuccessExecuted = true, e => onFailureExecuted = true);

            Assert.IsFalse(onSuccessExecuted);
            Assert.IsTrue(onFailureExecuted);
        }
    }
}
