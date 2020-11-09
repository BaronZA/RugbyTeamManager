using RugbyTeamManager.Database.DBModels;
using System;

namespace RugbyTeamManager.Database.DBContext
{
    public static class TeamManagerContextSeed
    {
        public static void LoadDefaultMemoryStadiums(TeamManagerContext context)
        {
            //throw new NotImplementedException();
        }

        public static void LoadDefaultMemoryTeams(TeamManagerContext context)
        {
            context.Teams.Add(new Team("Western Province", "Stormers"));

            context.SaveChanges();
        }

        public static void LoadDefaultMemoryPlayers(TeamManagerContext context)
        {
            context.Players.Add(new Player("John", "Smith", 1.83, "Hooker", new DateTime(1992, 05, 11)));
            context.Players.Add(new Player("Joseph", "Mbeli", 1.77, "Scrum-half", new DateTime(1995, 07, 21)));
            context.Players.Add(new Player("Mack", "Beth", 1.9, "Full Back", new DateTime(1990, 11, 06)));

            context.SaveChanges();
        }
    }
}
