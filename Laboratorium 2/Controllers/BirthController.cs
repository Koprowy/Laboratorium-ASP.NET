using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_2.Controllers
{
    public class Birth
    {
        [Required(ErrorMessage = "Pole 'Imię' jest wymagane.")]
        public string Imie { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        [Required(ErrorMessage = "Pole 'Data urodzenia' jest wymagane.")]
        public DateTime DataUrodzenia { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Imie) && DataUrodzenia < DateTime.Now;
        }
    }
    public class BirthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Birth model)
        {
            if (ModelState.IsValid && model.IsValid())
            {
                int wiek = ObliczWiek(model.DataUrodzenia);
                ViewBag.Message = $"Cześć {model.Imie}, masz {wiek} lat(a).";
            }
            else
            {
                ViewBag.Message = "Błąd: Niepoprawne dane.";
            }
            return View();
        }

        private int ObliczWiek(DateTime dataUrodzenia)
        {
            DateTime dzisiaj = DateTime.Today;
            int wiek = dzisiaj.Year - dataUrodzenia.Year;
            if (dataUrodzenia.Date > dzisiaj.AddYears(-wiek))
            {
                wiek--;
            }
            return wiek;
        }

    }
}
