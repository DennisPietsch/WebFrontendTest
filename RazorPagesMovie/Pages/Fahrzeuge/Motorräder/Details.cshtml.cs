using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Fahrzeuge.Motorräder
{
    [AllowAnonymous]
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Models.AuthenticationContext _context;

        public DetailsModel(RazorPagesMovie.Models.AuthenticationContext context)
        {
            _context = context;
        }

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
    }
}
