using src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Services
{

    internal class GameService : IService<Game>
    {
        private Dictionary<int, Game> _games = new Dictionary<int, Game>();

        public Game Add(Game game)
        {
            game.SetId(_games.Count + 1);
            _games.Add(_games.Count + 1, game);
            return game;
        }

        public List<Game> GetAll()
        {
            return _games.Values.ToList();
        }

        public void Delete(int id)
        {
            _games.Remove(id);
        }

        public void Update(int id, Game game)
        {
            _games[id] = game;
        }
        public Game Get(int id)
        {
               return _games[id];
        }
    }
}
