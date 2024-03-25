using Microsoft.Extensions.DependencyInjection;
using src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Services
{
    internal class TeamService
    {
        private Dictionary<int, Team> _teams = new Dictionary<int, Team>();

        public Team AddTeam(string name)
        {
            int id = _teams.Count + 1;
            Team team = new Team(id, name);
            _teams.Add(team.id, team);
            return team;
        }

        public TeamWithPlayers GetTeam(int id)
        {
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();

            if (!_teams.ContainsKey(id))
            {
                return null;
            }

            List<Player> players = playerService.GetPlayersForTeam(id);

            return new TeamWithPlayers(_teams[id].id, _teams[id].name, players);
        }

        public List<Team> GetTeams()
        {
               return _teams.Values.ToList();
        }

        public List<TeamWithPlayers> GetTeamsWithPLayers()
        {
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();

            List<Player> players = playerService.GetAllPlayers();

            List<TeamWithPlayers> teamsWithPlayers = new List<TeamWithPlayers>();

            foreach (var team in _teams)
            {
                List<Player> teamPlayers = players.Where(p => p.teamId == team.Key).ToList();
                teamsWithPlayers.Add(new TeamWithPlayers(team.Value.id, team.Value.name, teamPlayers));
            }

            return teamsWithPlayers;
        }
    }
}
