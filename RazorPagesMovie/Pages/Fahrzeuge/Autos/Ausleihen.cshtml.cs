using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace RazorPagesMovie.Pages.Fahrzeuge.Autos
{
    [Authorize]
    public class AusleihenModel : PageModel
    {
        private readonly RazorPagesMovie.Models.AuthenticationContext _context;

        public AusleihenModel(RazorPagesMovie.Models.AuthenticationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            else
            {
                ID = (int)id;
            }

            return Page();
        }

        public Auto Auto { get; set; }

        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public DateTime AusleihenBIS { get; set; }
 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            Auto = await _context.Auto.FirstOrDefaultAsync(m => m.ID == ID);

            Auto.AusgeliehenBIS = AusleihenBIS;

            Auto.Verfuegbar = false;
            Auto.AusgeliehenUM = DateTime.Now;
            Auto.Kundenname = User.Identity.Name;

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
