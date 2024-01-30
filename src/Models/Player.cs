using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public int gamesPlayed { get; set; }
        public int gamesWon { get; set; }
        public int teamId { get; set; }

        public Player(int id, string name, string userName, int gamesPlayed, int gamesWon, int teamId)
        {
            this.id = id;
            this.name = name;
            this.userName = userName;
            this.gamesPlayed = gamesPlayed;
            this.gamesWon = gamesWon;
            this.teamId = teamId;
        }

    }
}
