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
        public ICommand OnAddNewPlayer { get; }
        public event PropertyChangedEventHandler PropertyChanged;


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
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();
            teamService.AddTeam("Team 1");
            teamService.AddTeam("Team 2");
            OnAddNewTeam = new Command(AddNewTeam);
            OnAddNewPlayer = new Command(AddPlayer);
            displayedPlayers = new ObservableCollection<Player>(playerService.GetAllPlayers());
            displayedTeams = new ObservableCollection<Team>(teamService.GetTeams());
        }

        public void AddNewTeam()
        {
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();
            teamService.AddTeam(TeamName);
            displayedTeams = new ObservableCollection<Team>(teamService.GetTeams());
            OnPropertyChanged("displayedTeams");
        }


        public List<Team> GetTeams()
        {
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();
            return teamService.GetTeams();
        }
    
        public void AddPlayer()
        {
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();
            playerService.AddPlayer(_playerName, _playerUserName, _teamSelected.id);
            displayedPlayers = new ObservableCollection<Player>(playerService.GetAllPlayers());
            OnPropertyChanged("displayedPlayers");
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
