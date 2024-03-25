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
        
        public void AddGame(string name, DateTime date, int idTeam1, int idTeam2, int killsTeam1, int killsTeam2)
        {
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();

            TeamWithPlayers team1WithPlayers = teamService.GetTeam(idTeam1);
            TeamWithPlayers team2WithPlayers = teamService.GetTeam(idTeam2);

            _games.Add(_games.Count + 1, new Game(_games.Count + 1, name, date, team1WithPlayers, team2WithPlayers, killsTeam1, killsTeam2));
        }

        public List<Game> GetGames()
        {
            return _games.Values.ToList();
        }
    }
}
