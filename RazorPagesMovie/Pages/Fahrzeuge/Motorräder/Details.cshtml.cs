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

        public Motorrad Motorrad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogError("Error occured while watching detailed at a Motorcycle");
                return NotFound();
            }

            Motorrad = await _context.Motorrad.FirstOrDefaultAsync(m => m.ID == id);

            if (Motorrad == null)
            {
                _logger.LogError("Error occured while watching detailed at a Motorcycle");
                return NotFound();
            }

            if (User.Identity.Name == null)
            {
                _logger.LogInformation("Not Logged or Registrated user looked at detailed Motorcycle {0}", Motorrad.ID);
            }
            else
            {
                _logger.LogInformation("{0} looked at detailed Motorcycle {1}", User.Identity.Name, Motorrad.ID);
            }

            return Page();
        }
    }
}
