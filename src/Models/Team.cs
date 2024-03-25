using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; } 

        public Team(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }

    public class TeamWithPlayers : Team
    {
        public List<Player> players { get; set; }

        public TeamWithPlayers(int id, string name, List<Player> players) : base(id, name)
        {
            this.players = players;
        }
    }
}
