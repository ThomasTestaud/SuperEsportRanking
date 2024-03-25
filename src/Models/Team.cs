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
        public int gamesPlayed { get; set; }
        public int gamesWon { get; set; }   

        public Team(int id, string name, int gamesPlayed, int gamesWon)
        {
            this.id = id;
            this.name = name;
            this.gamesPlayed = gamesPlayed;
            this.gamesWon = gamesWon;
        }
    }

    public class TeamWithPlayers : Team
    {
        public List<Player> players { get; set; }

        public TeamWithPlayers(int id, string name, int gamesPlayed, int gamesWon, List<Player> players) : base(id, name, gamesPlayed, gamesWon)
        {
            this.players = players;
        }
    }
}
