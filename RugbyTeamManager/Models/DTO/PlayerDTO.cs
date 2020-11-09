using System;
using System.ComponentModel.DataAnnotations;

namespace RugbyTeamManager.Models.DTO
{
    public class PlayerDTO
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public string Position { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int? TeamId { get; set; }
    }
}
