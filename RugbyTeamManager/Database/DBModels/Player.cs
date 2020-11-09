using System;

namespace RugbyTeamManager.Database.DBModels
{
    public class Player
    {
        public Player()
        {

        }
        public Player(string firstName, string lastName, double height, double weight, string position, DateTime dateOfBirth, int? teamId = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Height = height;
            Weight = weight;
            Position = position;
            DateOfBirth = dateOfBirth;
            TeamId = teamId;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
