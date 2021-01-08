using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Fahrzeuge
{
    public class OverviewModel : PageModel
    {
        private readonly RazorPagesMovie.Models.AuthenticationContext _context;

        public OverviewModel(RazorPagesMovie.Models.AuthenticationContext context)
        {
            _context = context;
        }

        public IList<Fahrzeug> fahrzeugliste { get; set; }
        public IList<Fahrzeug> kundenfahrzeuge { get; set; }

        public double gesamtausleihzeit { get; set; }

        public async Task OnGetAsync()
        {
            fahrzeugliste = await _context.Fahrzeug.ToListAsync();

            kundenfahrzeuge = new List<Fahrzeug>();
            
            foreach (var item in fahrzeugliste)
            {
                if (item.Verfuegbar == false && item.Kundenname == User.Identity.Name)
                {
                    var dauer = item.AusgeliehenBIS - item.AusgeliehenUM;

                    gesamtausleihzeit = dauer.TotalHours;

                    item.Gesamtpreis = item.Preis * (decimal) gesamtausleihzeit;

                    kundenfahrzeuge.Add(item);

                    gesamtausleihzeit = 0;
                }
            }
    
            foreach (var fahrzeug in fahrzeugliste)
            {
                if (fahrzeug.AusgeliehenBIS <= DateTime.Now)
                {
                    fahrzeug.Verfuegbar = true;
                    fahrzeug.Kundenname = null;
                    fahrzeug.AusgeliehenBIS = new DateTime();
                    fahrzeug.AusgeliehenUM = new DateTime();
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
