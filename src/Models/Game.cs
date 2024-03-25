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
        private List<Player> _players;

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

        public List<Player> players
        {
            get => _players;
            set
            {
                _players = value;
                OnPropertyChanged(nameof(players));
            }
        }

        public Game(int id, string name, DateTime date, int score, List<Player> players)
        {
            this._id = id;
            this._name = name;
            this._date = date;
            this._score = score;
            this._players = players;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
