using LumeraDX_Calc.Models;
using LumeraDX_Calc.Services;
using System.Web.Mvc;

namespace LumeraDX_Calc.Controllers
{
    public class HomeController : Controller
    {
        public const string AnswerIs = "The answer is: ";
        private ICalculator _calculator;
        public HomeController()
        {
            _calculator = new Calculator();
        }

        public HomeController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel calculateModel)
        {
            _calculator.Calculate(calculateModel.SelectedOperation, calculateModel.SelectedOperandOne, calculateModel.SelectedOperandTwo)
                .Match(onSuccess: val =>
                {
                    calculateModel.ResultString = $"{AnswerIs}{val}";
                },
                onError: e =>
                {
                    calculateModel.ResultString = $"{AnswerIs}{e.Message}";
                });

            return View(calculateModel);
        }
    }
}