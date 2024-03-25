using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.Models;

namespace src.Services
{
    internal class PlayerService
    {
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public void AddPlayer(string name, string userName, int teamId)
        {
            Player player = new Player(_players.Count + 1, name, userName, teamId);
            _players.Add(player.id, player);
        }

        public List<Player> GetPlayersForTeam(int teamId)
        {
            return _players.Values.Where(p => p.teamId == teamId).ToList();
        }

        public List<Player> GetAllPlayers()
        {
            return _players.Values.ToList();
        }

    }
}
