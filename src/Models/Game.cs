using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    public class Game
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public TeamWithPlayers team1 { get; set; }
        public TeamWithPlayers team2 { get; set; }
        public int kills { get; set; }

        public Game( int id, string name, DateTime date, TeamWithPlayers team1, TeamWithPlayers team2)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.team1 = team1;
            this.team2 = team2;
        }   
    }
}
