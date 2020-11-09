using Microsoft.EntityFrameworkCore;
using RugbyTeamManager.Database.DBModels;

namespace RugbyTeamManager.Database.DBContext
{
    public class TeamManagerContext : DbContext
    {
        public TeamManagerContext(DbContextOptions<TeamManagerContext> options) : base(options)
        {
        }

        public TeamManagerContext()
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
    }
}
