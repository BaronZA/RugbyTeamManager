﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RugbyTeamManager.Database.DBContext;
using RugbyTeamManager.Database.DBModels;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Player;
using System.Linq;

namespace RugbyTeamManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly TeamManagerContext _context;

        public PlayerController(ILogger<PlayerController> logger, TeamManagerContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("GetPlayer")]
        public ActionResult<GetPlayerResponse> GetPlayer(int id)
        {
            var response = new GetPlayerResponse();

            var player = _context.Players.FirstOrDefault(t => t.Id == id);

            if (player == null)
                return NotFound(response);

            response.Player.Id = player.Id;
            response.Player.FirstName = player.FirstName;
            response.Player.LastName = player.LastName;
            response.Player.Height = player.Height;
            response.Player.Weight = player.Weight;
            response.Player.Position = player.Position;
            response.Player.DateOfBirth = player.DateOfBirth;
            response.Player.TeamId = player.TeamId;


            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllPlayers")]
        public ActionResult<GetPlayersResponse> GetAllPlayers()
        {
            var response = new GetPlayersResponse();

            var players = _context.Players.ToList();

            foreach (var player in players)
            {
                response.Players.Add(new PlayerDTO() 
                {
                    Id = player.Id,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Height = player.Height,
                    Weight = player.Weight,
                    Position = player.Position,
                    DateOfBirth = player.DateOfBirth,
                    TeamId = player.TeamId
                });
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("CreatePlayer")]
        public ActionResult<CreatePlayerResponse> CreatePlayer(CreatePlayerRequest request)
        {
            var response = new CreatePlayerResponse() {ResponseMessage = Models.ResponseMessage.Failure };

            int? teamId = request.Player.TeamId == 0 ? null : request.Player.TeamId;
            _context.Players.Add(new Player(request.Player.FirstName, request.Player.LastName, request.Player.Height, request.Player.Weight, request.Player.Position, request.Player.DateOfBirth, teamId));

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdatePlayer")]
        public ActionResult<UpdatePlayerResponse> UpdatePlayer(UpdatePlayerRequest request)
        {
            var response = new UpdatePlayerResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var player = _context.Players.FirstOrDefault(t => t.Id == request.Player.Id);

            if (player == null)
                return NotFound(response);

            player.FirstName = request.Player.FirstName;
            player.LastName = request.Player.LastName;
            player.Height = request.Player.Height;
            player.Weight = request.Player.Weight;
            player.Position = request.Player.Position;
            player.DateOfBirth = request.Player.DateOfBirth;
            player.TeamId = request.Player.TeamId == 0 ? null : request.Player.TeamId;

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeletePlayer")]
        public ActionResult<DeletePlayerResponse> DeletePlayer(int id)
        {
            var response = new DeletePlayerResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var player = _context.Players.FirstOrDefault(t => t.Id == id);

            _context.Players.Remove(player);
            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }

        [HttpPut]
        [Route("TransferPlayerToTeam")]
        public ActionResult<TransferPlayerToTeamResponse> TransferPlayerToTeam(TransferPlayerToTeamRequest request)
        {
            var response = new TransferPlayerToTeamResponse() { ResponseMessage = Models.ResponseMessage.Failure };

            var player = _context.Players.FirstOrDefault(t => t.Id == request.PlayerId);
            var team = _context.Teams.FirstOrDefault(t => t.Id == request.TeamId);

            if(player == null || team == null)
                return NotFound(response);

            player.TeamId = team.Id;

            var success = _context.SaveChanges();

            if (success > 0)
                response.ResponseMessage = Models.ResponseMessage.Success;

            return Ok(response);
        }
    }
}
