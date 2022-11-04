using Microsoft.EntityFrameworkCore;
using NtaraCode.Models;
using NtaraCode.Services.EFCore;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Text.Json;

namespace NtaraCode.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamDbContext _context;
        public TeamService()
        {
            var options = new DbContextOptionsBuilder<TeamDbContext>()
                .UseInMemoryDatabase("Teams")
                .Options;

            _context = new TeamDbContext(options);
        }
        public IEnumerable<Team>GetTeams()
            => _context.Teams.ToList();
    }

    public interface ITeamService
    {
        IEnumerable<Team> GetTeams();
    }
}
