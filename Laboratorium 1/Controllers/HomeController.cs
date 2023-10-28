 using Laboratorium_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Laboratorium_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Calculator(Operator op)
        {
            string a = Request.Query["a"];
            string b = Request.Query["b"];
            string result = Request.Query["result"];

            double? parsedA = double.TryParse(a, out double aVal) ? aVal : (double?)null;
            double? parsedB = double.TryParse(b, out double bVal) ? bVal : (double?)null;
            double? parsedR = double.TryParse(result, out double resultVal) ? resultVal : (double?)null;
            if (op== Operator.Add)
            {
                ViewBag.Op = "+";
                ViewBag.Result = parsedA+ parsedB;
            }
            if (op== Operator.Sub)
            {
                ViewBag.Op = "-";
                ViewBag.Result = parsedA- parsedB;
            }
            if (op== Operator.Mul)
            {
                ViewBag.Op = "*";
                ViewBag.Result = parsedA* parsedB;
            }
            if (op == Operator.Div)
            {
                ViewBag.Op = "/";
                ViewBag.Result = parsedA / parsedB;
            }
            if (op == Operator.Unknown)
            {
                ViewBag.Op = "Unknown";
                ViewBag.Result = "?";
            }

            ViewBag.a = parsedA;
            ViewBag.b = parsedB;
            return View();
        }
        public enum Operator
        {
           Unknown, Add, Mul, Sub, Div
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}