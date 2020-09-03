using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Hersteller { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preis { get; set; }

        [RegularExpression(@"(0-9)")]
        [Range(0, 9)]
        public int SitzPlaetze { get; set; }

        [RegularExpression(@"(0-9)")]
        [Range(0, 3)]
        public int Raeder { get; set; }

        [RegularExpression(@"(0-9)")]
        [Range(0, 1000)]
        public int Leistung { get; set; }

        [RegularExpression(@"(0-9)")]
        public int Bauhjahr { get; set; }

        [RegularExpression(@"^[a-zA-Z ]*$")]
        [Required]
        [StringLength(30)]
        public string kundenname { get; set; }

        /*public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z ]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }*/
    }
}
