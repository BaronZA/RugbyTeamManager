namespace RugbyTeamManager.Database.DBModels
{
    public class Stadium
    {
        public Stadium()
        {
              
        }
        public Stadium(string name, string address, int seatCount)
        {
            Name = name;
            Address = address;
            SeatCount = SeatCount;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SeatCount { get; set; }
    }
}
