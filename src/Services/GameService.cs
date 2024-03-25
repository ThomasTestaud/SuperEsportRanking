using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Services
{
    internal class GameService
    {
        private Dictionary<int, Models.Game> _games = new Dictionary<int, Models.Game>();
        
        public void AddGame(Models.Game game)
        {
            _games.Add(game.id, game);
        }
    }
}
