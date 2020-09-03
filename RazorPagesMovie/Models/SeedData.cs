using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Hersteller = "Audi",
                        Bauhjahr = 2018,
                        Leistung = 210,
                        Preis = 12.50M,
                        SitzPlaetze = 5,
                        Raeder = 4,
                        kundenname = ""
                    },

                    new Movie
                    {
                        Hersteller = "VW",
                        Bauhjahr = 2009,
                        Leistung = 150,
                        Preis = 7.50M,
                        SitzPlaetze = 5,
                        Raeder = 4,
                        kundenname = ""
                    },

                    new Movie
                    {
                        Hersteller = "Mercedes Benz",
                        Bauhjahr = 2019,
                        Leistung = 300,
                        Preis = 16.50M,
                        SitzPlaetze = 5,
                        Raeder = 4,
                        kundenname = ""
                    },

                    new Movie
                    {
                        Hersteller = "Toyota",
                        Bauhjahr = 2005,
                        Leistung = 120,
                        Preis = 5,
                        SitzPlaetze = 5,
                        Raeder = 4,
                        kundenname = ""
                    }
                ) ; ;
                context.SaveChanges();
            }
        }
    }
}