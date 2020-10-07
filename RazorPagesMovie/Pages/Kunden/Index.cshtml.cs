using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.SqlServer;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using RazorPagesMovie.Authorization;

namespace RazorPagesMovie.Pages.Kunden
{
    [AllowAnonymous]
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(
            AuthenticationContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IList<Kunde> Kunde { get;set; }
        public IList<IdentityUser> UserList { get; set; }

        public async Task OnGetAsync()
        {
            var contacts = from c in Context.Kunde
                           select c;

            var isAuthorized = User.IsInRole(Constants.ContactManagersRole) ||
                               User.IsInRole(Constants.ContactAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized)
            {
                contacts = contacts.Where(c => c.Status == ContactStatus.Approved
                                            || c.OwnerID == currentUserId);
            }

            var users = await Context.Users.ToListAsync();

            UserList = users;

            Kunde = await contacts.ToListAsync();

            foreach (var user in UserList)
            {
                foreach (var item in Kunde)
                {
                    if (user.Email == item.Email)
                    {
                        user.UserName = item.Name;
                    }
                }
            }
        }
    }
}
