using RugbyTeamManager.Models.DTO;
using System.Collections.Generic;

namespace RugbyTeamManager.Models.Player
{
    public class GetPlayers
    {
        public List<PlayerDTO> Players { get; set; } = new List<PlayerDTO>();
    }
}
