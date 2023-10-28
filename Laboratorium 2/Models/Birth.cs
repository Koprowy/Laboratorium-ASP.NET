using System;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_2.Models
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
}