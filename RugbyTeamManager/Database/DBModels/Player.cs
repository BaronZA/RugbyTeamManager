using System;

namespace RugbyTeamManager.Database.DBModels
{
    public class Player
    {
        public Player()
        {

        }
        public Player(string firstName, string lastName, int age, DateTime dateOfBirth, int? teamId = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            DateOfBirth = dateOfBirth;
            TeamId = teamId;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
