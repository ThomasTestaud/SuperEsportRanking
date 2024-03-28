using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    internal class Team : Model
    {
        private int _id;
        private string _name;

        public int id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
        }

        public string name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        public Team(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

    }

    internal class TeamWithPlayers : Team
    {
        public List<Player> players { get; set; }

        public TeamWithPlayers(int id, string name, List<Player> players) : base(id, name)
        {
            this.players = players;
        }
    }
}
