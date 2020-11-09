using RugbyTeamManager.Models.DTO;

namespace RugbyTeamManager.Models.Player
{
    public class GetPlayerResponse : BaseResponse
    {
        public PlayerDTO Player { get; set; }
    }
}
