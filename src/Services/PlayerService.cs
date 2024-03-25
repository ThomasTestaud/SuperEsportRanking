using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Services
{
    internal class PlayerService
    {
        private Dictionary<int, Models.Player> _players = new Dictionary<int, Models.Player>();

        public void AddPlayer(string name, string userName, int teamId)
        {
            Models.Player player = new Models.Player(_players.Count + 1, name, userName, teamId);
            _players.Add(player.id, player);
        }

        public <List>Models.Player GetPlayersForTeam(int teamId)
        {
            return _players.Values.Where(p => p.teamId == teamId).ToList();
        }

        public <List>Models.Player GetAllPlayers()
        {
            return _players.Values.ToList();
        }

    }
}
