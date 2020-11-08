using Microsoft.AspNetCore.Mvc;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Stadium;

namespace RugbyTeamManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StadiumController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllStadiumsTEST")]
        public GetStadiums GetAllStadiumsTEST()
        {
            var result = new GetStadiums();

            result.Stadiums.Add(new StadiumDTO() { Name = "Wanderers" });
            result.Stadiums.Add(new StadiumDTO() { Name = "FNB " });
            result.Stadiums.Add(new StadiumDTO() { Name = "Ellis Park" });

            return result;
        }
    }
}