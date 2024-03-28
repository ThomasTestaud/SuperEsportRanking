using Microsoft.Extensions.DependencyInjection;
using src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Services
{
    internal class TeamService : IService<Team>
    {
        private Dictionary<int, Team> _teams = new Dictionary<int, Team>();

        public Team Add(Team team)
        {
            team.SetId(_teams.Count + 1);
            _teams.Add(_teams.Count + 1, team);
            return team;
        }

        public TeamWithPlayers GetTeamWithPlayers(int id)
        {
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();

            if (!_teams.ContainsKey(id))
            {
                return null;
            }

            List<Player> players = playerService.GetPlayersForTeam(id);

            return new TeamWithPlayers(_teams[id].name, players);
        }

        public List<Team> GetAll()
        {
               return _teams.Values.ToList();
        }

        public Team Get(int id)
        {
            return _teams[id];
        }

        public void Update(int id, Team team)
        {
            _teams[id] = team;
        }

        public void Delete(int id)
        {
            _teams.Remove(id);
        }

        public List<TeamWithPlayers> GetTeamsWithPLayers()
        {
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();

            List<Player> players = playerService.GetAll();

            List<TeamWithPlayers> teamsWithPlayers = new List<TeamWithPlayers>();

            foreach (var team in _teams)
            {
                List<Player> teamPlayers = players.Where(p => p.teamId == team.Key).ToList();
                teamsWithPlayers.Add(new TeamWithPlayers(team.Value.name, teamPlayers));
            }

            return teamsWithPlayers;
        }
    }
}
