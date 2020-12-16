using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Fahrzeuge.Motorräder
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AuthenticationContext _context;

        public IndexModel(
            ILogger<IndexModel> logger,
            AuthenticationContext context
            )
        {
            _context = context;
            _logger = logger;
        }

        public IList<Motorrad> Motorrad { get;set; }

        public async Task OnGetAsync()
        {
            if (User.Identity.Name == null)
            {
                _logger.LogInformation("Not logged in User is on Motorrad Verleih Index");
            }

            else
            {
                _logger.LogInformation("{0} is on Motorrad Verleih Index", User.Identity.Name);
            }

            Motorrad = await _context.Motorrad.ToListAsync();

            foreach (var fahrzeug in Motorrad)
            {
                if (fahrzeug.AusgeliehenUM.AddMinutes(fahrzeug.Ausleihzeit) <= DateTime.Now)
                {
                    fahrzeug.Verfuegbar = true;
                    fahrzeug.Kundenname = null;

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
