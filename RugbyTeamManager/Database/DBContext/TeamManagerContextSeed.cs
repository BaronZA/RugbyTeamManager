        using RugbyTeamManager.Database.DBModels;
using System;

namespace RugbyTeamManager.Database.DBContext
{
    public static class TeamManagerContextSeed
    {
        public static void LoadDefaultMemoryStadiums(TeamManagerContext context)
        {
            context.Stadiums.Add(new Stadium("Newlands Stadium", "Cape Town", 51900));

            context.SaveChanges();
        }

        public static void LoadDefaultMemoryTeams(TeamManagerContext context)
        {
            context.Teams.Add(new Team("Western Province", "Stormers", "Cape Town"));

            context.SaveChanges();
        }

        public static void LoadDefaultMemoryPlayers(TeamManagerContext context)
        {
            context.Players.Add(new Player("John", "Smith", 1.83, 100, "Hooker", new DateTime(1992, 05, 11)));
            context.Players.Add(new Player("Joseph", "Mbeli", 1.77, 105, "Scrum-half", new DateTime(1995, 07, 21)));
            context.Players.Add(new Player("Mack", "Beth", 1.9, 114.2, "Full Back", new DateTime(1990, 11, 06)));

            context.SaveChanges();
        }
    }
}
