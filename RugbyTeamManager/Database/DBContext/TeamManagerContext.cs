using Microsoft.EntityFrameworkCore;
using RugbyTeamManager.Database.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RugbyTeamManager.Database.DBContext
{
    public class TeamManagerContext : DbContext
    {
        public TeamManagerContext(DbContextOptions<TeamManagerContext> options) : base(options)
        {
            LoadDefaultMemoryStadiums();
            LoadDefaultMemoryTeams();
            LoadDefaultMemoryPlayers();
        }


        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }

        private void LoadDefaultMemoryStadiums()
        {
            //throw new NotImplementedException();
        }

        private void LoadDefaultMemoryTeams()
        {
            Teams.Local.Add(new Team("Western Province", "Stormers"));
        }

        public void LoadDefaultMemoryPlayers()
        {
            Players.Local.Add(new Player("John", "Smith", 1.83, "Hooker", new DateTime(1992, 05, 11)));
            Players.Local.Add(new Player("Joseph", "Mbeli", 1.77, "Scrum-half", new DateTime(1995, 07, 21)));
            Players.Local.Add(new Player("Mack", "Beth", 1.9, "Full Back", new DateTime(1990, 11, 06)));
        }
        
        public List<Player> GetPlayers()
        {
            return Players.Local.ToList();
        }

        public Player GetPlayer(int id)
        {
            return Players.Local.FirstOrDefault(t => t.Id == id);
        }

        public bool CreatePlayer(string firstName, string lastName, double height, string position, DateTime dateOfBirth, int? teamId = null)
        {
            Players.Local.Add(new Player(firstName, lastName, height, position, dateOfBirth, teamId));

            return true;
        }

        public bool UpdatePlayer(int id, string firstName, string lastName, double height, string position, DateTime dateOfBirth, int? teamId = null)
        {
            var player = Players.Local.FirstOrDefault(t => t.Id == id);

            if (player == null)
                return false;

            
            player.FirstName = firstName;
            player.LastName = lastName;
            player.Height = height;
            player.Position = position;
            player.DateOfBirth = dateOfBirth;
            player.TeamId = teamId;

            return true;    
        }

        public bool DeletePlayer(int id)
        {
            var player = Players.Local.FirstOrDefault(t => t.Id == id);

            if (player == null)
                return false;

            Players.Local.Remove(player);

            return true;
        }

        public bool LinkPlayerToTeam(int playerId, int teamId)
        {
            var player = Players.Local.FirstOrDefault(t => t.Id == playerId);
            var team = Teams.Local.FirstOrDefault(t => t.Id == teamId);

            if (player == null || team == null)
                return false;

            player.TeamId = team.Id;

            return true;
        }
    }
}
