using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Models;
using System;
using RazorPagesMovie;
using RazorPagesMovie.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Serilog;
using Serilog.Events;

namespace RazorPagesMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.File("C:/Users/DennisP/Desktop/logger.txt")
                .Enrich.FromLogContext()
                .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<AuthenticationContext>();
                    context.Database.Migrate();

                    var config = host.Services.GetRequiredService<IConfiguration>();

                    SeedData.Initialize(services).Wait();

                    Log.Information("Starting Web Host");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "There went something wrong");

                    /*var log = new LoggerConfiguration()
                        .WriteTo.Console()
                        .CreateLogger();

                    log.Information("Hello, Serilog!");fdasfsadfasdfsadfasdfadsfasdf

                    Log.Logger = log;
                    Log.Information("The global logger has been configurated");
                    
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");

                    logger.LogError(ex, "Ein Fehler bei der Datenbank ist aufgetreten");*/
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureLogging(loggerinfo =>
                {
                    loggerinfo.ClearProviders();
                    
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}  
