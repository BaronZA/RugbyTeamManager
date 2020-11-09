namespace RugbyTeamManager.Database.DBModels
{
    public class Team
    {
        public Team()
        {

        }
        public Team(string name, string nickname, int? stadiumId = null)
        {
            Name = name;
            Nickname = nickname;
            StadiumId = stadiumId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Location { get; set; }
        public int? StadiumId { get; set; }
        public virtual Stadium Stadium { get; set; }
    }
}
