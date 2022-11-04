using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NtaraCode.Models;
using NtaraCode.Services;

namespace NtaraCode.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ITeamService _teamService;
        public IEnumerable<Team> Teams { get; private set; }
        public IndexModel(ILogger<IndexModel> logger, ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;

        }
        public void OnGet()
        {
            //TODO: Convert to Task Async
            Teams = _teamService.GetTeams();
        }
    }
}