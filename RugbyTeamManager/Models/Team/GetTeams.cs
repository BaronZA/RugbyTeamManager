using RugbyTeamManager.Models.DTO;
using System.Collections.Generic;

namespace RugbyTeamManager.Models.Team
{
    public class GetTeams
    {
        public List<TeamDTO> Teams { get; set; } = new List<TeamDTO>();
    }
}
