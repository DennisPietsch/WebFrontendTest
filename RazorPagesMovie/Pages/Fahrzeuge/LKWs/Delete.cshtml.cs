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
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;
        private readonly AuthenticationContext _context;

        public DeleteModel(
            ILogger<DeleteModel> logger,
            AuthenticationContext context
            )
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public LKW LKW { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogError("LKW is not found and can be deleted");
                return NotFound();
            }

            LKW = await _context.LKW.FirstOrDefaultAsync(m => m.ID == id);

            if (LKW == null)
            {
                _logger.LogError("LKW is not found and can be deleted");
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogError("LKW is not found and can be deleted");
                return NotFound();
            }

            LKW = await _context.LKW.FindAsync(id);

            if (LKW != null)
            {
                _context.LKW.Remove(LKW);
                await _context.SaveChangesAsync();
                _logger.LogDebug("LKW is Deleted by User {0}", User.Identity.Name);
            }

            return RedirectToPage("./Index");
        }
    }
}
