using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Authorization;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Kunden
{
    public class EditModel : DI_BasePageModel
    {
        public EditModel(
            RazorPagesMovieContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Kunde Kunde { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Kunde = await Context.Kunde.FirstOrDefaultAsync(
                                            m => m.ID == id);

            if (Kunde == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Kunde,
                                                        ContactOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var contact = await Context
                .Kunde.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                    User, contact,
                                                    ContactOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Kunde.OwnerID = contact.OwnerID;

            Context.Attach(Kunde).State = EntityState.Modified;

            if (Kunde.Status == ContactStatus.Approved)
            {
                var canApprove = await AuthorizationService.AuthorizeAsync(User,
                                        Kunde,
                                        ContactOperations.Approve);

                if (!canApprove.Succeeded)
                {
                    Kunde.Status = ContactStatus.Submitted;
                }

                await Context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return NotFound();
        }
    }
}
