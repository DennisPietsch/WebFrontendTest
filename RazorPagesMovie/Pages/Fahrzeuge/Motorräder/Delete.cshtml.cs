using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Fahrzeuge.Motorräder
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Models.AuthenticationContext _context;

        public DeleteModel(RazorPagesMovie.Models.AuthenticationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Motorrad Motorrad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Motorrad = await _context.Motorrad.FirstOrDefaultAsync(m => m.ID == id);

            if (Motorrad == null)
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

            Motorrad = await _context.Motorrad.FindAsync(id);

            if (Motorrad != null)
            {
                _context.Motorrad.Remove(Motorrad);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
