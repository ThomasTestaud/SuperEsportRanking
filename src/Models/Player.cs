using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Models
{
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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

        public Player(int id, string name, string userName, int teamId)
        {
            this.id = id;
            this.name = name;
            this.userName = userName;
            this.teamId = teamId;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
