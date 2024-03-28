using src.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using src.Models;
using Microsoft.Maui.Controls; 
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace src.ViewModels
{


    internal class GamesViewModel : ViewModel
    {
        public ObservableCollection<Game> displayedGames { get; set; }
        public ObservableCollection<Team> availableTeams { get; set; }
        public ObservableCollection<Player> availablePlayers { get; set; }
        public string newGameName { get; set; }
        public DateTime newGameDate { get; set; }

        public bool _gameType;
        public bool _oGameType;

        private Team _newGameTeam1;
        private Team _newGameTeam2;

        private Player _newPlayer1;
        private Player _newPlayer2;

        private string _name1;
        private string _name2;

        public int score1 { get; set; }
        public int score2 { get; set; }
        public ICommand AddGameCommand { get; }
        
        public GamesViewModel()
        {
            displayedGames = new ObservableCollection<Game>(gameService.GetAll());
            availableTeams = new ObservableCollection<Team>(teamService.GetAll());
            availablePlayers = new ObservableCollection<Player>(playerService.GetAll());


            AddGameCommand = new Command(AddGame);
        }

        public bool gameType
        {
            get => _gameType;
            set
            {
                if (_gameType != value)
                {
                    _gameType = value;
                    OnPropertyChanged(nameof(gameType));
                    this.oGameType = !value;
                }
            }
        }

        public bool oGameType
        {
            get => _oGameType;
            set
            {
                if (_oGameType != value)
                {
                    _oGameType = value;
                    OnPropertyChanged(nameof(oGameType));
                }
            }
        }

        public Team newGameTeam1
        {
            get => _newGameTeam1;
            set
            {
                if (_newGameTeam1 != value)
                {
                    _newGameTeam1 = value;
                    _name1 = _newGameTeam1.name;
                    OnPropertyChanged(nameof(newGameTeam1));
                }
            }
        }

        public Team newGameTeam2
        {
            get => _newGameTeam2;
            set
            {
                if (_newGameTeam2 != value)
                {
                    _newGameTeam2 = value;
                    _name2 = _newGameTeam2.name;
                    OnPropertyChanged(nameof(newGameTeam2));
                }
            }
        }

        public Player newPlayer1
        {
            get => _newPlayer1;
            set
            {
                if (_newPlayer1 != value)
                {
                    _newPlayer1 = value;
                    _name1 = _newPlayer1.name;
                    OnPropertyChanged(nameof(newPlayer1));
                }
            }
        }

        public Player newPlayer2
        {
            get => _newPlayer2;
            set
            {
                if (_newPlayer2 != value)
                {
                    _newPlayer2 = value;
                    _name2 = _newPlayer2.name;
                    OnPropertyChanged(nameof(newPlayer2));
                }
            }
        }

        private void AddGame()
        {

            Game newGame = new Game(newGameName, newGameDate, score1, score2, gameType, _name1, _name2);
            gameService.Add(newGame);

            displayedGames = new ObservableCollection<Game>(gameService.GetAll());

            OnPropertyChanged(nameof(displayedGames));
        }

        

        private void DeleteGame(int id)
        {
            gameService.Delete(id);
            displayedGames = new ObservableCollection<Game>(gameService.GetAll());
            OnPropertyChanged(nameof(displayedGames));
        }

    }
}
