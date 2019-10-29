using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LumeraDX_Calc.Models
{
    public class HomeViewModel
    {
        public static IEnumerable<SelectListItem> Operations = MathOperation.AvailableOperations.Select(mo => new SelectListItem { Text = mo.Index, Value = mo.Index });
        public static List<int> OperandOneList { get; } = Enumerable.Range(0, 100).ToList();
        public static List<int> OperandTwoList { get; } = Enumerable.Range(0, 100).ToList();

        public int SelectedOperandOne { get; set; }
        public int SelectedOperandTwo { get; set; }
        public string SelectedOperation { get; set; } = MathOperation.AddSymbol;
        public string ResultString { get; set; } = String.Empty;
    }
}