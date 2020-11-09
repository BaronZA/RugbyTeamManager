namespace RugbyTeamManager.Models.DTO
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Location { get; set; }
        public int? StadiumId { get; set; }
    }
}
