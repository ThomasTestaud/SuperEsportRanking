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
        
        public void AddTeamGame(string name, DateTime date, Team team, int score)
        {
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();

            TeamWithPlayers teamWithPlayers = teamService.GetTeam(team.id);

            _games.Add(_games.Count + 1, new GameWithTeams(_games.Count + 1, name, date, score, teamWithPlayers));
        }

        public List<Game> GetGames()
        {
            return _games.Values.ToList();
        }
    }
}
