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

namespace RazorPagesMovie.Pages.Fahrzeuge.LKWs
{
    [AllowAnonymous]
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Models.AuthenticationContext _context;

        public DetailsModel(RazorPagesMovie.Models.AuthenticationContext context)
        {
            _context = context;
        }

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
    }
}
