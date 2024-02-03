using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("photos")]
    public class PhotoEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        public DateTime DateTaken { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Camera { get; set; }
       
        [MaxLength(100)]
        public string Author { get; set; }

        [MaxLength(50)]
        public string Resolution { get; set; }

        [MaxLength(50)]
        public string Format { get; set; }

        [MaxLength(50)]
        public string Location { get; set; }
    }
}