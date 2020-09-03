using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    public class Kunde
    {
        [RegularExpression(@"a-zA-Z")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression(@"a-zA-Z")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string VorName { get; set; }

        [Range (18, 1000)]
        [Required]
        public int alter { get; set; }

        [RegularExpression(@"a-zA-Z ")]
        [Required]
        public string Stadt { get; set; }
    }
}
