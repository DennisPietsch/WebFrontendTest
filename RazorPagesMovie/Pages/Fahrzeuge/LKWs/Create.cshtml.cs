using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Fahrzeuge.LKWs
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Models.AuthenticationContext _context;

        public CreateModel(RazorPagesMovie.Models.AuthenticationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LKW LKW { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            LKW.Verfuegbar = true;
            _context.LKW.Add(LKW);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
