using RugbyTeamManager.Models.DTO;
using System.Collections.Generic;

namespace RugbyTeamManager.Models.Stadium
{
    public class GetStadiumsResponse
    {
        public List<StadiumDTO> Stadiums { get; set; } = new List<StadiumDTO>();
    }
}
