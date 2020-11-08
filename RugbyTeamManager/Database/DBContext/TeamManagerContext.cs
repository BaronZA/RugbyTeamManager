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

        public void LoadDefaultMemoryPlayers()
        {
            Players.Add(new Player("John", "Smith", 28, new DateTime(1992, 05, 11)));
            Players.Add(new Player("Joseph", "Mbeli", 25, new DateTime(1995, 07, 21)));
            Players.Add(new Player("Mack", "Beth", 30, new DateTime(1990, 11, 06)));
        }
        private void LoadDefaultMemoryStadiums()
        {
            //throw new NotImplementedException();
        }

        private void LoadDefaultMemoryTeams()
        {
            //throw new NotImplementedException();
        }

        public List<Player> GetPlayers()
        {
            return Players.Local.ToList();
        }
    }
}
