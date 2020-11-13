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

namespace RazorPagesMovie.Pages.Fahrzeuge.LKWs
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

        public LKW LKW { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogError("Error occured while watching detailed at a LKW");
                return NotFound();
            }

            LKW = await _context.LKW.FirstOrDefaultAsync(m => m.ID == id);

            if (LKW == null)
            {
                _logger.LogError("Error occured while watching detailed at a LKW");
                return NotFound();
            }

            if (User.Identity.Name == null)
            {
                _logger.LogInformation("Not Logged or Registrated user looked at detailed LKW {0}", LKW.ID);
            }
            else
            {
                _logger.LogInformation("{0} looked at detailed LKW {1}", User.Identity.Name, LKW.ID);
            }

            return Page();
        }
    }
}
