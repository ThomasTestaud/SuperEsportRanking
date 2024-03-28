using System.ComponentModel;
using System.Windows.Input;
using src.Services;
using src.Models;
using System.Collections.ObjectModel;

namespace src.ViewModels
{
    internal class PlayersViewModel : ViewModel

    {
        public ICommand OnAddNewTeam { get; }
        public ICommand OnAddNewPlayer { get; }


        private string _playerName;
        private string _playerUserName;
        private Team _teamSelected;
        private string _teamName;
        public ObservableCollection<Player> displayedPlayers { get; set; }
        public ObservableCollection<Team> displayedTeams { get; set; }

        public string PlayerName
        {
            get => _playerName;
            set
            {
                _playerName = value;
                OnPropertyChanged("PlayerName");
            }
        }
        public string PlayerUserName
        {
            get => _playerUserName;
            set
            {
                _playerUserName = value;
                OnPropertyChanged("PlayerUserName");
            }
        }

        public Team TeamSelected
        {
            get => _teamSelected;
            set
            {
                _teamSelected = value;
                OnPropertyChanged("TeamSelected");
            }
        }
        public string TeamName
        {
            get => _teamName;
            set { 
                _teamName = value;
                OnPropertyChanged("TeamName");
            }
        }
        public PlayersViewModel() {
            OnAddNewTeam = new Command(AddNewTeam);
            OnAddNewPlayer = new Command(AddPlayer);
            displayedPlayers = new ObservableCollection<Player>(playerService.GetAllPlayers());
            displayedTeams = new ObservableCollection<Team>(teamService.GetTeams());
        }

        public void AddNewTeam()
        {
            teamService.AddTeam(TeamName);
            displayedTeams = new ObservableCollection<Team>(teamService.GetTeams());
            OnPropertyChanged("displayedTeams");
        }


        public List<Team> GetTeams()
        {
            return teamService.GetTeams();
        }
    
        public void AddPlayer()
        {
            playerService.AddPlayer(_playerName, _playerUserName, _teamSelected.id);
            displayedPlayers = new ObservableCollection<Player>(playerService.GetAllPlayers());
            OnPropertyChanged("displayedPlayers");
        }

    }
}
