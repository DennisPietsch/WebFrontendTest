using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesMovie.Pages.Role
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.AuthenticationContext _context;

        public IndexModel(RazorPagesMovie.Models.AuthenticationContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
        }
    }
}
