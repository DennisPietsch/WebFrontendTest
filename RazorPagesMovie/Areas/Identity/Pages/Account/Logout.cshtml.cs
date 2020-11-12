using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.File;

namespace RazorPagesMovie.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("C:/Users/DennisP/Desktop/logger.txt")
                .CreateLogger();

            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out");

            if (returnUrl != null)
            {
                _logger.LogInformation("User logged out test 2");
                return LocalRedirect(returnUrl);
            }
            else
            {
                _logger.LogError("Error occured with log out");
                return RedirectToPage();
            }
        }
    }
}
