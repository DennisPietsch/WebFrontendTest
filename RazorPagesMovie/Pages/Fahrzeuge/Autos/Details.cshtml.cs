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

namespace RazorPagesMovie.Pages.Fahrzeuge.Autos
{
    [AllowAnonymous]
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly AuthenticationContext _context;

        public DetailsModel(
            ILogger<DetailsModel> logger,
            AuthenticationContext context
            )
        {
            _logger = logger;
            _context = context;
        }

        public Auto Auto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogError("Error occured while watching detailed at a Car");
                return NotFound();
            }

            Auto = await _context.Auto.FirstOrDefaultAsync(m => m.ID == id);

            if (Auto == null)
            {
                _logger.LogError("Error occured while watching detailed at a Car");
                return NotFound();
            }

            if (User.Identity.Name == null)
            {
                _logger.LogInformation("Not Logged or Registrated user looked at detailed Car {0}", Auto.ID);
            }
            else
            {
                _logger.LogInformation("{0} looked at detailed Car {1}", User.Identity.Name, Auto.ID);
            }

            return Page();
        }
    }
}
