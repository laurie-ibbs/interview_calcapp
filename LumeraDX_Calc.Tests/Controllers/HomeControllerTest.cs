using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LumeraDX_Calc.Controllers;
using LumeraDX_Calc.Models;
using LumeraDX_Calc.Services;
using Moq;

namespace LumeraDX_Calc.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        Mock<ICalculator> _mockCalculator;
        
        [TestInitialize]
        public void Setup()
        {
            _mockCalculator = new Mock<ICalculator>();
        }

        [TestMethod]
        public void WHEN_pristine_THEN_selected_operands_are_zero()
        {
            HomeController controller = new HomeController(_mockCalculator.Object);

            ViewResult result = controller.Index() as ViewResult; //GET
            var model = result.Model as HomeViewModel;

            Assert.AreEqual(0, model.SelectedOperandOne);
            Assert.AreEqual(0, model.SelectedOperandTwo);
        }

        [TestMethod]
        public void WHEN_pristine_THEN_selected_operation_is_plus()
        {
            HomeController controller = new HomeController(_mockCalculator.Object);

            ViewResult result = controller.Index() as ViewResult; //GET
            var model = result.Model as HomeViewModel;

            Assert.AreEqual("+", model.SelectedOperation);
        }

        [TestMethod]
        public void GIVEN_calculation_success_THEN_model_contains_answer()
        {
            SetupWellBehavedCalculation();
            HomeViewModel viewModel = new HomeViewModel
            {
                SelectedOperandOne = 1, //any values
                SelectedOperandTwo = 0, //any values
                SelectedOperation = "AnyOperation"
            };
            HomeController controller = new HomeController(_mockCalculator.Object);

            ViewResult result = controller.Index(viewModel) as ViewResult; //POST
            var model = result.Model as HomeViewModel;

            Assert.AreEqual("The answer is: 1", model.ResultString);
        }

        [TestMethod]
        public void GIVEN_calculation_success_THEN_model_contains_error_info()
        {
            SetupBadlyBehavedCalculation();
            HomeViewModel viewModel = new HomeViewModel
            {
                SelectedOperandOne = 1, //any values
                SelectedOperandTwo = 0, //any values
                SelectedOperation = "AnyOperation"
            };
            HomeController controller = new HomeController(_mockCalculator.Object);

            ViewResult result = controller.Index(viewModel) as ViewResult; //POST
            var model = result.Model as HomeViewModel;

            Assert.AreEqual("The answer is: Attempted to divide by zero.", model.ResultString);
        }

        private void SetupWellBehavedCalculation()
        {
            _mockCalculator.Setup(c => c.Calculate(
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()
                )).Returns(
                    new Result<int>(1)
                );
        }

        private void SetupBadlyBehavedCalculation()
        {
            _mockCalculator.Setup(c => c.Calculate(
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()
                )).Returns(
                    new Result<int>(0, new DivideByZeroException())
                );
        }
    }
}
