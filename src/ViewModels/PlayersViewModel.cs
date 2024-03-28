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

        public ICommand goToScoresCommand { get; }
        public ICommand goToGamesCommand { get; }
        public PlayersViewModel() {
            teamService.Add(TeamSelected = new Team("Team 1"));
            teamService.Add(TeamSelected = new Team("Team 2"));
            OnAddNewTeam = new Command(AddNewTeam);
            OnAddNewPlayer = new Command(AddPlayer);
            displayedPlayers = new ObservableCollection<Player>(playerService.GetAll());
            displayedTeams = new ObservableCollection<Team>(teamService.GetAll());
            goToScoresCommand = new Command(goToScores);
            goToGamesCommand = new Command(goToGames);
        }

        async public void goToScores()
        {
            await Shell.Current.GoToAsync("//main/section/ScoresPage");
        }

        async public void goToGames()
        {
            GamesViewModel gamesViewModel = ServiceLocator.ServiceProvider.GetService<GamesViewModel>();
            gamesViewModel.loadAllCollections();
            await Shell.Current.GoToAsync("//main/section/GamesPage");
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

    }
}
