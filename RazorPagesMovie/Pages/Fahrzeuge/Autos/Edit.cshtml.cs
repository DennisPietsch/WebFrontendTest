﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Fahrzeuge.Autos
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly AuthenticationContext _context;

        public EditModel(
            ILogger<EditModel> logger,
            AuthenticationContext context
            )
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Auto Auto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogError("Error Fahrzeug not found");
                return NotFound();
            }

            Auto = await _context.Auto.FirstOrDefaultAsync(m => m.ID == id);

            if (Auto == null)
            {
                _logger.LogError("Error Fahrzeug not found");
                return NotFound();
            }

            _logger.LogInformation("User {0} is changing Car {1}", User.Identity.Name, Auto.ID);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Auto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                
                _logger.LogDebug("Changes saved to Fahrzeug ID {0} from User {1}", Auto.ID, User.Identity.Name);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoExists(Auto.ID))
                {
                    _logger.LogError("Error occured while Editing");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AutoExists(int id)
        {
            return _context.Auto.Any(e => e.ID == id);
        }
    }
}
