using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Authorization;
using RazorPagesMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            List<Fahrzeug> Fahrzeugliste = new List<Fahrzeug>();

            using (var context = new AuthenticationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AuthenticationContext>>()))
            {
                Fahrzeugliste.Add(
                    new Auto
                    {
                        Hersteller = "Audi",
                        Preis = 3.90m,
                        SitzPlaetze = 5,
                        Raeder = 4,
                        Anhängerkupplung = true,
                        Leistung = 200,
                        Bauhjahr = 2019
                    });

                Fahrzeugliste.Add(
                    new Auto
                    {
                        Hersteller = "VW",
                        Preis = 2.30m,
                        SitzPlaetze = 5,
                        Raeder = 4,
                        Anhängerkupplung = false,
                        Leistung = 150,
                        Bauhjahr = 2017
                    });

                Fahrzeugliste.Add(
                    new Auto
                    {
                        Hersteller = "VW",
                        Preis = 2.30m,
                        SitzPlaetze = 5,
                        Raeder = 4,
                        Anhängerkupplung = false,
                        Leistung = 150,
                        Bauhjahr = 2017
                    });

                Fahrzeugliste.Add(
                    new Auto
                    {
                        Hersteller = "Mercedes",
                        Preis = 4.50m,
                        SitzPlaetze = 5,
                        Raeder = 4,
                        Anhängerkupplung = true,
                        Leistung = 220,
                        Bauhjahr = 2019
                    });

                Fahrzeugliste.Add(
                    new Motorrad
                    {
                        Hersteller = "Ducati",
                        Preis = 1.20m,
                        SitzPlaetze = 5,
                        Raeder = 4,
                        SeitenWagen = false,
                        Leistung = 200,
                        Bauhjahr = 2019
                    });

                Fahrzeugliste.Add(
                    new Auto
                    {
                        Hersteller = "Audi",
                        Preis = 3.90m,
                        SitzPlaetze = 5,
                        Raeder = 4,
                        Anhängerkupplung = true,
                        Leistung = 200,
                        Bauhjahr = 2019
                    });

                context.Fahrzeug.AddRange(Fahrzeugliste);

                context.SaveChanges();
            }

                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@contoso.com");
                await EnsureRole(serviceProvider, adminID, Constants.ContactAdministratorsRole);

                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@contoso.com");
                await EnsureRole(serviceProvider, managerID, Constants.ContactManagersRole);
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                              string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
    }
}