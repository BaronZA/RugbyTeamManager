using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RugbyTeamManager.Database.DBContext;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Player;
using System;
using System.Data.Entity.Infrastructure;
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

            var playersDb = _context.GetPlayers();

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

            var success = _context.CreatePlayer(request.Player.FirstName, request.Player.LastName, request.Player.Height, request.Player.Position, request.Player.DateOfBirth, request.Player.TeamId);

            if (success)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpPut]
        [Route("UpdatePlayer")]
        public UpdatePlayerResponse UpdatePlayer(UpdatePlayerRequest request)
        {
            var response = new UpdatePlayerResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var success = _context.UpdatePlayer(request.Player.Id, request.Player.FirstName, request.Player.LastName, request.Player.Height, request.Player.Position, request.Player.DateOfBirth, request.Player.TeamId);

            if (success)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpDelete]
        [Route("DeletePlayer")]
        public DeletePlayerResponse DeletePlayer(int id)
        {
            var response = new DeletePlayerResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var success = _context.DeletePlayer(id);

            if (success)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpPut]
        [Route("LinkPlayerToTeam")]
        public LinkPlayerToTeamResponse LinkPlayerToTeamPlayer(LinkPlayerToTeamRequest request)
        {
            var response = new LinkPlayerToTeamResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var success = _context.LinkPlayerToTeam(request.PlayerId, request.TeamId);

            if (success)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }
    }
}
