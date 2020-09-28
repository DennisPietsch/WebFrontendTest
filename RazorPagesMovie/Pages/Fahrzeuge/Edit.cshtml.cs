using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Fahrzeuge
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovie.Models.AuthenticationContext _context;

        public EditModel(RazorPagesMovie.Models.AuthenticationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fahrzeug Fahrzeug { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fahrzeug = await _context.Fahrzeug_1.FirstOrDefaultAsync(m => m.ID == id);

            if (Fahrzeug == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Fahrzeug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FahrzeugExists(Fahrzeug.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FahrzeugExists(int id)
        {
            return _context.Fahrzeug_1.Any(e => e.ID == id);
        }
    }
}
