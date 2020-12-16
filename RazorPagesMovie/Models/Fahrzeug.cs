using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Fahrzeug
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Hersteller { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preis { get; set; }

        public int SitzPlaetze { get; set; }

        public int Raeder { get; set; }

        public int Leistung { get; set; }

        public int Bauhjahr { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z ]*$")]
        [StringLength(30)]
        public string Kundenname { get; set; }

        public bool Verfuegbar { get; set; }

        public DateTime AusgeliehenUM { get; set; }

        public DateTime AusgeliehenBIS { get; set; }
    }
}
