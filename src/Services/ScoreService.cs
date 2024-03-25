﻿using src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace src.Services
{
    internal class ScoreService
    {
        public List<Game> getGamePerBestRatio()
        {
            GameService gameService = ServiceLocator.ServiceProvider.GetService<GameService>();

            var games = gameService.GetGames();

            var bestRatio = games.Max(g => g.killsTeam1 / g.killsTeam2);

            return games.Where(g => g.killsTeam1 / g.killsTeam2 == bestRatio).ToList();
        }
    }
}
