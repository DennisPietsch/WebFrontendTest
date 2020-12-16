using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using RazorPagesMovie.Areas;
using Microsoft.Extensions.Logging;

namespace RazorPagesMovie.Pages.Fahrzeuge.Autos
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

        public IList<Auto> Auto { get;set; }

        public async Task OnGetAsync()
        {
            if (User.Identity.Name == null)
            {
                _logger.LogInformation("Not logged in User is on Auto Verleih Index");
            }

            else
            {
                _logger.LogInformation("{0} is on Auto Verleih Index", User.Identity.Name);
            }

            Auto = await _context.Auto.ToListAsync();

            foreach (var fahrzeug in Auto)
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
