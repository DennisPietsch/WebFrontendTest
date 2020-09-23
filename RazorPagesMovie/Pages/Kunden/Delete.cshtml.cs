using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Authorization;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Kunden
{
    public class DeleteModel : DI_BasePageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public DeleteModel(
            RazorPagesMovieContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Kunde Kunde { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Kunde = await Context.Kunde.FirstOrDefaultAsync(
                                            m => m.ID == id);

            if (Kunde == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Kunde,
                                                        ContactOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var contact = await Context
                .Kunde.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Kunde == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                    User, Kunde,
                                                    ContactOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Kunde.Remove(contact);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
