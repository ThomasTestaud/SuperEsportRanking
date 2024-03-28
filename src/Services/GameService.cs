﻿using src.Models;
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
        
        public void AddTeamGame(string name, DateTime date, List<Player> players, int score)
        {
            _games.Add(_games.Count + 1, new Game(_games.Count + 1, name, date, score, players));
        }

        public List<Game> GetGames()
        {
            return _games.Values.ToList();
        }

        public void DeleteGame(int id)
        {
            _games.Remove(id);
        }

        public void UpdateGame(int id, string name, DateTime date, int score)
        {
            _games[id].name = name;
            _games[id].date = date;
            _games[id].score = score;
        }
    }
}
