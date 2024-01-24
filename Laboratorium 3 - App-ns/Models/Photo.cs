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
        public DateTime DateTaken { get; set; }

        [StringLength(500, ErrorMessage = "Opis jest za długi.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę aparatu!")]
        public string Camera { get; set; }

        [Required(ErrorMessage = "Proszę podać autora zdjęcia!")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Proszę podać rozdzielczość zdjęcia!")]
        public string Resolution { get; set; }

        [Required(ErrorMessage = "Proszę podać format zdjęcia!")]
        public string Format { get; set; }
    }
}