using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Player;

namespace RugbyTeamManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
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
    }
}
