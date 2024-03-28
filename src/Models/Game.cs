using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace src.Models
{
    internal class Game : Model
    {
        private int _id;
        private string _name;
        private DateTime _date;
        private int _score1;
        private int _score2;
        private bool _teamGame;
        private string _team1;
        private string _team2;


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

        public int score1
        {
            get => _score1;
            set
            {
                _score1 = value;
                OnPropertyChanged(nameof(score1));
            }
        }
        
        public int score2
        {
            get => _score2;
            set
            {
                _score2 = value;
                OnPropertyChanged(nameof(score2));
            }
        }

        public bool teamGame
        {
            get => _teamGame;
            set
            {
                _teamGame = value;
                OnPropertyChanged(nameof(teamGame));
            }
        }
        public string team1
        {
            get => _team1;
            set
            {
                _team1 = value;
                OnPropertyChanged(nameof(team1));
            }
        }

        public string team2
        {
            get => _team2;
            set
            {
                _team2 = value;
                OnPropertyChanged(nameof(team2));
            }
        }

        public Game( string name, DateTime date, int score1, int score2, bool teamGame, string team1, string team2) : base()
        {
            this.name = name;
            this.date = date;
            this.score1 = score1;
            this.score2 = score2;
            _teamGame = teamGame;
            _team1 = team1;
            _team2 = team2;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
    }

}
