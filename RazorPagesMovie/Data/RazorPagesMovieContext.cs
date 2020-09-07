using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Fahrzeug> Fahrzeug_1 { get; set; }

        public DbSet<RazorPagesMovie.Models.Kunde> Kunde { get; set; }

        public DbSet<RazorPagesMovie.Models.Auto> Auto { get; set; }

        public DbSet<RazorPagesMovie.Models.LKW> LKW { get; set; }

        public DbSet<RazorPagesMovie.Models.Motorrad> Motorrad { get; set; }
    }
}
