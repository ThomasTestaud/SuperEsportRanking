using src.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using src.Models;
using Microsoft.Maui.Controls; 
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace src.ViewModels
{
    internal class GamesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Game> displayedGames { get; set; }
        public ObservableCollection<Team> availableTeams { get; set; }
        public string newGameName { get; set; }
        public DateTime newGameDate { get; set; }
        public int newGameScore { get; set; }
        private Team _newGameTeam;
        public ICommand AddGameCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public GamesViewModel()
        {
            GameService gameService = ServiceLocator.ServiceProvider.GetService<GameService>();
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();

            displayedGames = new ObservableCollection<Game>(gameService.GetAll());
            availableTeams = new ObservableCollection<Team>(teamService.GetAll());

            //newGameDate = DateTime.Now;

            AddGameCommand = new Command(AddGame);
        }

        public Team newGameTeam
        {
            get => _newGameTeam;
            set
            {
                if (_newGameTeam != value)
                {
                    _newGameTeam = value;
                    OnPropertyChanged(nameof(newGameTeam));
                }
            }
        }

        private void AddGame()
        {
            GameService gameService = ServiceLocator.ServiceProvider.GetService<GameService>();
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();

            TeamWithPlayers teamWithPlayers = teamService.GetTeamWithPlayers(newGameTeam.id);
            List<Player> players = teamWithPlayers.players;

            gameService.Add(new Game(newGameName, newGameDate,newGameScore, players ));

            displayedGames = new ObservableCollection<Game>(gameService.GetAll());

            OnPropertyChanged(nameof(displayedGames));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DeleteGame(int id)
        {
            GameService gameService = ServiceLocator.ServiceProvider.GetService<GameService>();
            gameService.Delete(id);
            displayedGames = new ObservableCollection<Game>(gameService.GetAll());
            OnPropertyChanged(nameof(displayedGames));
        }

    }
}
