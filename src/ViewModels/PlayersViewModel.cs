using System.ComponentModel;
using System.Windows.Input;
using src.Services;
using src.Models;
using System.Collections.ObjectModel;

namespace src.ViewModels
{
    public class PlayersViewModel : INotifyPropertyChanged

    {
        public ICommand OnAddNewTeam { get; }
        // public List<Team> teams = ;
        public event PropertyChangedEventHandler PropertyChanged;


        private string _playerName;
        private string _playerUserName;
        private Team _teamSelected;
        private string _teamName;
        public ObservableCollection<Player> displayedPlayers { get; set; }

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
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();
            OnAddNewTeam = new Command(AddNewTeam);
            displayedPlayers = new ObservableCollection<Player>(playerService.GetAllPlayers());
        }

        public void AddNewTeam()
        {
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();
            teamService.AddTeam(_teamName);
        }

        /*
        public List<Team> GetTeams()
        {
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();
            return teamService.GetTeams();
        } */
    
        public void addPlayer()
        {
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();
            playerService.AddPlayer(_playerName, _playerUserName, _teamSelected.id);
            displayedPlayers = new ObservableCollection<Player>(playerService.GetAllPlayers());
            OnPropertyChanged("players");
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
