using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RugbyTeamManager.Database.DBContext;
using RugbyTeamManager.Database.DBModels;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Stadium;
using System.Linq;

namespace RugbyTeamManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StadiumController : ControllerBase
    {
        private readonly ILogger<StadiumController> _logger;
        private readonly TeamManagerContext _context;

        public StadiumController(ILogger<StadiumController> logger, TeamManagerContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("GetStadium")]
        public ActionResult<GetStadiumResponse> GetStadium(int id)
        {
            var response = new GetStadiumResponse();

            var stadium = _context.Stadiums.FirstOrDefault(t => t.Id == id);

            if (stadium == null)
                return NotFound(response);

            response.Stadium.Id = stadium.Id;
            response.Stadium.Name = stadium.Name;
            response.Stadium.Address = stadium.Address;
            response.Stadium.SeatCount = stadium.SeatCount;

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllStadiums")]
        public ActionResult<GetStadiumsResponse> GetAllStadiums()
        {
            var response = new GetStadiumsResponse();

            var stadiums = _context.Stadiums.ToList();

            foreach (var stadium in stadiums)
            {
                response.Stadiums.Add(new StadiumDTO()
                {
                    Id = stadium.Id,
                    Name = stadium.Name,
                    Address = stadium.Address,
                    SeatCount = stadium.SeatCount
                });
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateStadium")]
        public ActionResult<CreateStadiumResponse> CreateStadium(CreateStadiumRequest request)
        {
            var response = new CreateStadiumResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            _context.Stadiums.Add(new Stadium(request.Stadium.Name, request.Stadium.Address, request.Stadium.SeatCount));
            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateStadium")]
        public ActionResult<UpdateStadiumResponse> UpdateStadium(UpdateStadiumRequest request)
        {
            var response = new UpdateStadiumResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var stadium = _context.Stadiums.FirstOrDefault(t => t.Id == request.Stadium.Id);

            if (stadium == null)
                return NotFound(response);

            stadium.Name = request.Stadium.Name;
            stadium.Address = request.Stadium.Address;
            stadium.SeatCount = request.Stadium.SeatCount;

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteStadium")]
        public ActionResult<DeleteStadiumResponse> DeleteStadium(int id)
        {
            var response = new DeleteStadiumResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var stadium = _context.Stadiums.FirstOrDefault(t => t.Id == id);

            if (stadium == null)
                return NotFound(response);

            _context.Stadiums.Remove(stadium);
            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }
    }
}