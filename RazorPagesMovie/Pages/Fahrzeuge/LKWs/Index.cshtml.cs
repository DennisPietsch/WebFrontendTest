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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.AuthenticationContext _context;

        public IndexModel(RazorPagesMovie.Models.AuthenticationContext context)
        {
            _context = context;
        }

        public IList<LKW> LKW { get;set; }

        public async Task OnGetAsync()
        {
            LKW = await _context.LKW.ToListAsync();
        }
    }
}
