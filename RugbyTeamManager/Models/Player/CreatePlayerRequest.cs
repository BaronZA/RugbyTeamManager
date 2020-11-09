using RugbyTeamManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyTeamManager.Models.Player
{
    public class CreatePlayerRequest
    {
        public PlayerDTO Player { get; set; }
    }
}
