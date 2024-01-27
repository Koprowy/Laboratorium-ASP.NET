using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App_ns.Models
{
    public class Photo
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać datę i godzinę zdjęcia!")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data wykonania")]
        public DateTime DateTaken { get; set; }

        [StringLength(500, ErrorMessage = "Opis jest za długi.")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę aparatu!")]
        [Display(Name = "Aparat")]
        public string Camera { get; set; }

        [Required(ErrorMessage = "Proszę podać autora zdjęcia!")]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Proszę podać rozdzielczość zdjęcia!")]
        [Display(Name = "Rozdzielczość")]
        public string Resolution { get; set; }

        [Required(ErrorMessage = "Proszę podać format zdjęcia!")]
        [Display(Name = "Format")]
        public string Format { get; set; }
        
        [Display(Name = "Kategoria")]
        public PhotoCategory Category { get; set; }
    }
}