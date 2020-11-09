using RugbyTeamManager.Models.DTO;
using System.Collections.Generic;

namespace RugbyTeamManager.Models.Team
{
    public class GetTeamsResponse
    {
        public List<TeamDTO> Teams { get; set; } = new List<TeamDTO>();
    }
}
