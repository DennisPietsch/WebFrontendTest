﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Fahrzeuge.LKWs
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AuthenticationContext _context;

        public IndexModel(
            ILogger<IndexModel> logger,
            AuthenticationContext context
            )
        {
            _context = context;
            _logger = logger;
        }

        public IList<LKW> LKW { get;set; }

        public async Task OnGetAsync()
        {
            if (User.Identity.Name == null)
            {
                _logger.LogInformation("Not logged in User is on LKW Verleih Index");
            }

            else
            {
                _logger.LogInformation("{0} is on LKW Verleih Index", User.Identity.Name);
            }

            LKW = await _context.LKW.ToListAsync();

            foreach (var fahrzeug in LKW)
            {
                if (fahrzeug.AusgeliehenUM.AddMinutes(fahrzeug.Ausleihzeit) <= DateTime.Now)
                {
                    fahrzeug.Verfuegbar = true;
                    fahrzeug.Kundenname = null;
                }
            }
        }
    }
}
