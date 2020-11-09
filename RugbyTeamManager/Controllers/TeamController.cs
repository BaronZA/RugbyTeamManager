using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RugbyTeamManager.Database.DBContext;
using RugbyTeamManager.Database.DBModels;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Team;
using System.Linq;

namespace RugbyTeamManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly TeamManagerContext _context;

        public TeamController(ILogger<TeamController> logger, TeamManagerContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("GetTeam")]
        public ActionResult<GetTeamResponse> GetTeam(int id)
        {
            var response = new GetTeamResponse();

            var team = _context.Teams.FirstOrDefault(t => t.Id == id);

            if (team == null)
                return NotFound(response);

            response.Team.Id = team.Id;
            response.Team.Name = team.Name;
            response.Team.Nickname = team.Nickname;
            response.Team.Location = team.Location;
            response.Team.StadiumId = team.StadiumId;

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllTeams")]
        public ActionResult<GetTeamsResponse> GetAllTeams()
        {
            var response = new GetTeamsResponse();

            var teams = _context.Teams.ToList();

            foreach (var team in teams)
            {
                response.Teams.Add(new TeamDTO()
                {
                    Id = team.Id,
                    Name = team.Name,
                    Nickname = team.Nickname,
                    Location = team.Location,
                    StadiumId = team.StadiumId
                });
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateTeam")]
        public ActionResult<CreateTeamResponse> CreateTeam(CreateTeamRequest request)
        {
            var response = new CreateTeamResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            int? stadiumId = request.Team.StadiumId == 0 ? null : request.Team.StadiumId;
            _context.Teams.Add(new Team(request.Team.Name, request.Team.Nickname, request.Team.Location, stadiumId));

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateTeam")]
        public ActionResult<UpdateTeamResponse> UpdateTeam(UpdateTeamRequest request)
        {
            var response = new UpdateTeamResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var team = _context.Teams.FirstOrDefault(t => t.Id == request.Team.Id);

            if (team == null)
                return NotFound(response);

            team.Name = request.Team.Name;
            team.Nickname = request.Team.Nickname;
            team.Location = request.Team.Location;
            team.StadiumId = request.Team.StadiumId == 0 ? null : request.Team.StadiumId;

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteTeam")]
        public ActionResult<DeleteTeamResponse> DeleteTeam(int id)
        {
            var response = new DeleteTeamResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var team = _context.Teams.FirstOrDefault(t => t.Id == id);

            if (team == null)
                return NotFound(response);

            _context.Teams.Remove(team);
            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }

        [HttpPut]
        [Route("LinkTeamToStadium")]
        public ActionResult<LinkTeamToStadiumResponse> LinkTeamToStadium(LinkTeamToStadiumRequest request)
        {
            var response = new LinkTeamToStadiumResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var team = _context.Teams.FirstOrDefault(t => t.Id == request.TeamId);
            var stadium = _context.Stadiums.FirstOrDefault(t => t.Id == request.StadiumId);

            if (team == null || stadium == null)
                return NotFound(response);

            team.StadiumId = stadium.Id;

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }
    }
}