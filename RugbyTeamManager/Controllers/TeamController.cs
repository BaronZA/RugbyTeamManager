using Microsoft.AspNetCore.Mvc;
using RugbyTeamManager.Database.DBContext;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Team;
using System.Linq;

namespace RugbyTeamManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly TeamManagerContext _context;

        public TeamController(TeamManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllTeamsTEST")]
        public GetTeams GetAllTeamsTEST()
        {
            var result = new GetTeams();

            result.Teams.Add(new TeamDTO() { Name = "Stormers" });
            result.Teams.Add(new TeamDTO() { Name = "Bulls" });
            result.Teams.Add(new TeamDTO() { Name = "Cheetahs" });

            return result;
        }

        
    }
}