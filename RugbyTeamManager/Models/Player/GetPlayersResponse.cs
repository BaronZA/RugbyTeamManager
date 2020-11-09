using RugbyTeamManager.Models.DTO;
using System.Collections.Generic;

namespace RugbyTeamManager.Models.Player
{
    public class GetPlayersResponse : BaseResponse
    {
        public List<PlayerDTO> Players { get; set; } = new List<PlayerDTO>();
    }
}
