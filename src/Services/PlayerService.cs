using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.Models;

namespace src.Services
{
    internal class PlayerService : IService<Player>
    {
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public Player Add(Player player)
        {
            player.SetId(_players.Count + 1);
            _players.Add(_players.Count + 1, player);
            return player;
        }

        public List<Player> GetPlayersForTeam(int teamId)
        {
            return _players.Values.Where(p => p.teamId == teamId).ToList();
        }

        public List<Player> GetAll()
        {
            return _players.Values.ToList();
        }

        public Player Get(int id)
        {
            return _players[id];
        }

        public void Update(int id, Player player)
        {
            _players[id] = player;
        }
        public void Delete(int id)
        {
            _players.Remove(id);
        }

    }
}
