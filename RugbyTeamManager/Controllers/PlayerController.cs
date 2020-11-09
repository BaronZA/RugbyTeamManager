using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RugbyTeamManager.Database.DBContext;
using RugbyTeamManager.Database.DBModels;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Player;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Xml;

namespace RugbyTeamManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly TeamManagerContext _context;

        public PlayerController(ILogger<PlayerController> logger, TeamManagerContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("GetAllPlayersTEST")]
        public GetPlayersResponse GetAllPlayersTEST()
        {
            var result = new GetPlayersResponse();

            result.Players.Add(new PlayerDTO() { FirstName = "Johnson" });
            result.Players.Add(new PlayerDTO() { FirstName = "Smith" });
            result.Players.Add(new PlayerDTO() { FirstName = "James" });
            result.Players.Add(new PlayerDTO() { FirstName = "Cage" });
            return result;
        }

        [HttpGet]
        [Route("GetAllPlayersDBTEST")]
        public GetPlayersResponse GetAllPlayersDBTEST()
        {
            var result = new GetPlayersResponse();

            var playersDb = _context.Players.ToList();

            foreach (var player in playersDb)
            {
                result.Players.Add(new PlayerDTO() { FirstName = player.FirstName });
            }

            return result;
        }

        [HttpGet]
        [Route("GetEDMX")]
        public string GetEDMX()
        {
            using (var ctx = new TestContext())
            {
                using (var writer = new XmlTextWriter(@"c:\Model.edmx", Encoding.Default))
                {
                    EdmxWriter.WriteEdmx(ctx, writer);
                }
            }

            return "Done";
        }

        [HttpPost]
        [Route("CreatePlayer")]
        public CreatePlayerResponse CreatePlayer(CreatePlayerRequest request)
        {
            var response = new CreatePlayerResponse() {ResponseMessage = Models.ResponseMessage.Failure };

            _context.Players.Add(new Player(request.Player.FirstName, request.Player.LastName, request.Player.Height, request.Player.Position, request.Player.DateOfBirth, request.Player.TeamId));
            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpPut]
        [Route("UpdatePlayer")]
        public UpdatePlayerResponse UpdatePlayer(UpdatePlayerRequest request)
        {
            var response = new UpdatePlayerResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var player = _context.Players.FirstOrDefault(t => t.Id == request.Player.Id);

            if (player == null)
                return response;

            player.FirstName = request.Player.FirstName;
            player.LastName = request.Player.LastName;
            player.Height = request.Player.Height;
            player.Position = request.Player.Position;
            player.DateOfBirth = request.Player.DateOfBirth;
            player.TeamId = request.Player.TeamId;

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpDelete]
        [Route("DeletePlayer")]
        public DeletePlayerResponse DeletePlayer(int id)
        {
            var response = new DeletePlayerResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var player = _context.Players.FirstOrDefault(t => t.Id == id);

            _context.Players.Remove(player);
            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpPut]
        [Route("LinkPlayerToTeam")]
        public LinkPlayerToTeamResponse LinkPlayerToTeamPlayer(LinkPlayerToTeamRequest request)
        {
            var response = new LinkPlayerToTeamResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var player = _context.Players.FirstOrDefault(t => t.Id == request.PlayerId);
            var team = _context.Teams.FirstOrDefault(t => t.Id == request.TeamId);

            if(player == null || team == null)
                return response;

            player.TeamId = team.Id;

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }
    }
}
