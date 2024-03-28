using src.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;



namespace src.Services
{
    
    internal class ScoreService
    {
        public ObservableCollection<scoreElement> getScoresPerPlayer()
        {
            // Get all games and players
            GameService gameService = ServiceLocator.ServiceProvider.GetService<GameService>();
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();

            // Get all games and players
            List<Game> gamesList = gameService.GetAll();
            List<Player> playerList = playerService.GetAll();

            ObservableCollection<scoreElement> scores = new ObservableCollection<scoreElement>();

            // Loop through all players and count the number of games they have won
            foreach (Player player in playerList)
            {
                var query = from game in gamesList
                             where (game.teamGame == false
                             && game.team1 == player.name
                             && game.score1 > game.score2)
                             || (game.teamGame == true
                             && game.team2 == player.name
                             && game.score1 < game.score2)
                             select game;

                int count = query.Count();

                scores.Add(new scoreElement { name = player.name, score = count });
            }

            return scores;
        }

    }
}
