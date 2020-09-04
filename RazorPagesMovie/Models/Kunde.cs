using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    public class Kunde
    {
        public int ID { get;set; }

        [RegularExpression(@"^[A-Za-z]*$")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Za-z]*$")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Vorname { get; set; }

        [Range (18, 1000)]
        [Required]
        public int Alter { get; set; }

        [RegularExpression(@"^[A-Za-z]*$")]
        [Required]
        public string Stadt { get; set; }
    }
}
