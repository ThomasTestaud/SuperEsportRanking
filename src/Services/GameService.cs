using src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Services
{

    internal class GameService
    {
        private Dictionary<int, Game> _games = new Dictionary<int, Game>();
        
        public void Add(string name, DateTime date, int score1, int score2, bool teamGame, string team1, string team2)
        {
            _games.Add(_games.Count + 1, new Game(_games.Count + 1, name, date, score1, score2, teamGame, team1, team2));
        }

        public List<Game> GetGames()
        {
            return _games.Values.ToList();
        }

        public void DeleteGame(int id)
        {
            _games.Remove(id);
        }

        public void UpdateGame(int id, string name, DateTime date, int score1, int score2, bool teamGame, string team1, string team2)
        {
            _games[id].name = name;
            _games[id].date = date;
            _games[id].score1 = score1;
            _games[id].score2 = score2;
            _games[id].teamGame = teamGame;
            _games[id].team1 = team1;
            _games[id].team2 = team2;
        }
    }
}
