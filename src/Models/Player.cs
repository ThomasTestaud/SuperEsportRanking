﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    internal class Player : Model
    {
        private int _id;
        private string _name;
        private string _userName;
        private int _teamId;


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
        public string userName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged("userName");
            }
        }

        public int teamId
        {
            get => _teamId;
            set
            {
                _teamId = value;
                OnPropertyChanged("teamId");
            }
        }

        public Player(string name, string userName, int teamId)
        {
            this.name = name;
            this.userName = userName;
            this.teamId = teamId;
        }
        public void SetId(int id)
        {
            this.id = id;
        }

    }
}
