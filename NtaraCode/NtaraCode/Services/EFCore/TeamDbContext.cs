using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

using NtaraCode.Models;
using System.Text.Json;

namespace NtaraCode.Services.EFCore
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options)
        : base(options)
        {
            this.Seed();
        }
        public DbSet<Team> Teams { get; set; }
    }
    public static class TeamSeeder
    {
        static string dir;
        static TeamSeeder()
        {
            dir = Directory.GetCurrentDirectory();
        }

        // TODO: public static IWebHostEnvironment _webHostEnvironment { get; }
        private static string JsonFileName 
            => Path.Combine(dir, "wwwroot","data","CollegeFootballTeamWinsWithMascots.json");
        static volatile bool seeded = false;
        public static void Seed(this TeamDbContext context)
        {
            if (!seeded && context.Teams.Count() == 0)
            {
                if (!seeded)
                {
                    var teams = GetTeams();

                    context.Teams.AddRange(teams);
                    context.SaveChanges();
                    seeded = true;
                }
            }
        }
        public static IEnumerable<Team> GetTeams()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Team[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

    }
}
    

