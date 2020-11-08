using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RugbyTeamManager.Database.DBContext;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Player;

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
        public GetPlayers GetAllPlayersTEST()
        {
            var result = new GetPlayers();

            result.Players.Add(new PlayerDTO() { Name = "Johnson" });
            result.Players.Add(new PlayerDTO() { Name = "Smith" });
            result.Players.Add(new PlayerDTO() { Name = "James" });
            result.Players.Add(new PlayerDTO() { Name = "Cage" });
            return result;
        }

        [HttpGet]
        [Route("GetAllPlayersDBTEST")]
        public GetPlayers GetAllPlayersDBTEST()
        {
            var result = new GetPlayers();

            var playersDb = _context.GetPlayers();

            foreach (var player in playersDb)
            {
                result.Players.Add(new PlayerDTO() { Name = player.FirstName });
            }

            return result;
        }
    }
}
