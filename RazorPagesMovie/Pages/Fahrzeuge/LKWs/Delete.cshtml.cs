using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Fahrzeuge.LKWs
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Models.AuthenticationContext _context;

        public DeleteModel(RazorPagesMovie.Models.AuthenticationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LKW LKW { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LKW = await _context.LKW.FirstOrDefaultAsync(m => m.ID == id);

            if (LKW == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LKW = await _context.LKW.FindAsync(id);

            if (LKW != null)
            {
                _context.LKW.Remove(LKW);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
