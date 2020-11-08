using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyTeamManager.Database.DBModels
{
    public class Stadium
    {
        public Stadium()
        {
              
        }
        public Stadium(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
