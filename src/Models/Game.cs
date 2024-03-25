using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace src.Models
{
    public class Game : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private DateTime _date;
        private int _score;

        public int id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }

        public string name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(name));
            }
        }

        public DateTime date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(date));
            }
        }

        public int score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged(nameof(score));
            }
        }

        public Game(int id, string name, DateTime date, int score)
        {
            this._id = id;
            this._name = name;
            this._date = date;
            this._score = score;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class GameWithTeams : Game
    {
        private Team _teams;

        public Team teams
        {
            get => _teams;
            set
            {
                _teams = value;
                OnPropertyChanged(nameof(teams));
            }
        }

        public GameWithTeams(int id, string name, DateTime date, int score, Team teams) : base(id, name, date, score)
        {
            this._teams = teams;
        }
    }

    public class GameWithPlayers : Game
    {
        private List<Player> _players;

        public List<Player> players
        {
            get => _players;
            set
            {
                _players = value;
                OnPropertyChanged(nameof(players));
            }
        }

        public GameWithPlayers(int id, string name, DateTime date, int score, List<Player> players) : base(id, name, date, score)
        {
            this._players = players;
        }
    }
}
