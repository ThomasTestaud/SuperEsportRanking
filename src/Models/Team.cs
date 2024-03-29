﻿using System;
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

        public Team(string name)
        {
            this.name = name;
        }
        public void SetId(int id)
        {
            this.id = id;
        }

    }

    internal class TeamWithPlayers : Team
    {
        public List<Player> players { get; set; }

        public TeamWithPlayers(string name, List<Player> players) : base(name)
        {
            this.players = players;
        }
    }
}
