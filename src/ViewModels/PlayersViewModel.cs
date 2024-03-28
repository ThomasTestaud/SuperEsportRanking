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
        public ICommand OnDeletePlayer { get; private set; }
        public ICommand OnDeleteTeam { get; private set; }


        private string _playerName;
        private string _playerUserName;
        private Team _teamSelected;
        private string _teamName;
        private Player _playerSelected;
        public ObservableCollection<Player> displayedPlayers { get; set; }
        public ObservableCollection<Team> displayedTeams { get; set; }


        public Player PlayerSelected
        {
            get => _playerSelected;
            set
            {
                _playerSelected = value;
                OnPropertyChanged("PlayerSelected");
            }
        }
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
            OnAddNewPlayer = new Command(AddPlayer);
            OnDeletePlayer = new Command(DeletePlayer);
            OnDeleteTeam = new Command(DeleteTeam);
            displayedPlayers = new ObservableCollection<Player>(playerService.GetAll());
            displayedTeams = new ObservableCollection<Team>(teamService.GetAll());
        }

        public void AddNewTeam()
        {
            teamService.Add(TeamSelected = new Team(TeamName));
            displayedTeams = new ObservableCollection<Team>(teamService.GetAll());
            OnPropertyChanged("displayedTeams");
        }


        public List<Team> GetTeams()
        {
            return teamService.GetAll();
        }
    
        public void AddPlayer()
        {
            playerService.Add(new Player(PlayerName, PlayerUserName, TeamSelected.id));
            displayedPlayers = new ObservableCollection<Player>(playerService.GetAll());
            OnPropertyChanged("displayedPlayers");
        }

        public void DeletePlayer(object parameter)
        {
            if(parameter is Player player)
            {
                playerService.Delete(player.id);
                displayedPlayers = new ObservableCollection<Player>(playerService.GetAll());
                OnPropertyChanged("displayedPlayers");
            }
            
        }

        public void DeleteTeam(object parameter)
        {
            if(parameter is Team team)
            {
                teamService.Delete(team.id);
                displayedTeams = new ObservableCollection<Team>(teamService.GetAll());
                OnPropertyChanged("displayedTeams");
            }
        }

    }
}
