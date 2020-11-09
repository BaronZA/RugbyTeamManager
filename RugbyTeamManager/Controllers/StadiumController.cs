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
        public GetStadiumResponse GetStadium(int id)
        {
            var response = new GetStadiumResponse();

            var stadium = _context.Stadiums.FirstOrDefault(t => t.Id == id);

            if (stadium == null)
                return response;

            response.Stadium.Id = stadium.Id;
            response.Stadium.Name = stadium.Name;
            response.Stadium.Address = stadium.Address;
            response.Stadium.SeatCount = stadium.SeatCount;

            return response;
        }

        [HttpGet]
        [Route("GetAllStadiums")]
        public GetStadiumsResponse GetAllStadiums()
        {
            var result = new GetStadiumsResponse();

            var stadiums = _context.Stadiums.ToList();

            foreach (var stadium in stadiums)
            {
                result.Stadiums.Add(new StadiumDTO()
                {
                    Id = stadium.Id,
                    Name = stadium.Name,
                    Address = stadium.Address,
                    SeatCount = stadium.SeatCount
                });
            }

            return result;
        }

        [HttpPost]
        [Route("CreateStadium")]
        public CreateStadiumResponse CreateStadium(CreateStadiumRequest request)
        {
            var response = new CreateStadiumResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            _context.Stadiums.Add(new Stadium(request.Stadium.Name, request.Stadium.Address, request.Stadium.SeatCount));
            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpPut]
        [Route("UpdateStadium")]
        public UpdateStadiumResponse UpdateStadium(UpdateStadiumRequest request)
        {
            var response = new UpdateStadiumResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var stadium = _context.Stadiums.FirstOrDefault(t => t.Id == request.Stadium.Id);

            if (stadium == null)
                return response;

            stadium.Name = request.Stadium.Name;
            stadium.Address = request.Stadium.Address;
            stadium.SeatCount = request.Stadium.SeatCount;

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }

        [HttpDelete]
        [Route("DeleteStadium")]
        public DeleteStadiumResponse DeleteStadium(int id)
        {
            var response = new DeleteStadiumResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var stadium = _context.Stadiums.FirstOrDefault(t => t.Id == id);

            _context.Stadiums.Remove(stadium);
            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return null;
        }
    }
}