using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Fahrzeuge.Motorräder
{
    public class AusleihenModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public AusleihenModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
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

        public Motorrad Motorrad { get; set; }

        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public int Ausleihzeit { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Motorrad = await _context.Motorrad.FirstOrDefaultAsync(m => m.ID == ID);

            Motorrad.Verfuegbar = false;
            Motorrad.Kundenname = "TestKunde";
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}