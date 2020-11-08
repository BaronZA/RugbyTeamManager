using Microsoft.AspNetCore.Mvc;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Team;

namespace RugbyTeamManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
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