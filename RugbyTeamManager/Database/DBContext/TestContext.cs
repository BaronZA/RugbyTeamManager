using RugbyTeamManager.Database.DBModels;
using System.Data.Entity;

namespace RugbyTeamManager.Database.DBContext
{
    public class TestContext : System.Data.Entity.DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
    }
}
