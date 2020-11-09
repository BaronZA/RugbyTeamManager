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
        public GetTeamResponse GetTeam(int id)
        {
            var response = new GetTeamResponse();

            var team = _context.Teams.FirstOrDefault(t => t.Id == id);

            if (team == null)
                return response;

            response.Team.Id = team.Id;
            response.Team.Name = team.Name;
            response.Team.Nickname = team.Nickname;
            response.Team.Location = team.Location;
            response.Team.StadiumId = team.StadiumId;

            return response;
        }

        [HttpGet]
        [Route("GetAllTeams")]
        public GetTeamsResponse GetAllTeams()
        {
            var result = new GetTeamsResponse();

            var teams = _context.Teams.ToList();

            foreach (var team in teams)
            {
                result.Teams.Add(new TeamDTO()
                {
                    Id = team.Id,
                    Name = team.Name,
                    Nickname = team.Nickname,
                    Location = team.Location,
                    StadiumId = team.StadiumId
                });
            }

            return result;
        }

        [HttpPost]
        [Route("CreateTeam")]
        public CreateTeamResponse CreateTeam(CreateTeamRequest request)
        {
            var response = new CreateTeamResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            int? stadiumId = request.Team.StadiumId == 0 ? null : request.Team.StadiumId;
            _context.Teams.Add(new Team(request.Team.Name, request.Team.Nickname, request.Team.Location, stadiumId));

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpPut]
        [Route("UpdateTeam")]
        public UpdateTeamResponse UpdateTeam(UpdateTeamRequest request)
        {
            var response = new UpdateTeamResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var team = _context.Teams.FirstOrDefault(t => t.Id == request.Team.Id);

            if (team == null)
                return response;

            team.Name = request.Team.Name;
            team.Nickname = request.Team.Nickname;
            team.Location = request.Team.Location;
            team.StadiumId = request.Team.StadiumId == 0 ? null : request.Team.StadiumId;

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpDelete]
        [Route("DeleteTeam")]
        public DeleteTeamResponse DeleteTeam(int id)
        {
            var response = new DeleteTeamResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var team = _context.Teams.FirstOrDefault(t => t.Id == id);

            _context.Teams.Remove(team);
            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpPut]
        [Route("LinkTeamToStadium")]
        public LinkTeamToStadiumResponse LinkTeamToStadium(LinkTeamToStadiumRequest request)
        {
            var response = new LinkTeamToStadiumResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var team = _context.Teams.FirstOrDefault(t => t.Id == request.TeamId);
            var stadium = _context.Stadiums.FirstOrDefault(t => t.Id == request.StadiumId);

            if (team == null || stadium == null)
                return response;

            team.StadiumId = stadium.Id;

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }
    }
}