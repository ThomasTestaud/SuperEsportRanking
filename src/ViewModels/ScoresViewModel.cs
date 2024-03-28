using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using src.Models;
using System.Collections.ObjectModel;


namespace src.ViewModels
{
    internal class ScoresViewModel : ViewModel
    {
        public ICommand goToGamesCommand { get; }
        public ICommand goToPlayersCommand { get; }

        public ObservableCollection<scoreElement> Scores { get; set; }

        public ScoresViewModel()
        {
            goToGamesCommand = new Command(goToGames);
            goToPlayersCommand = new Command(goToPlayers);
            Scores = scoreService.getScoresPerPlayer();
        }

        // Navigation
        async public void goToGames()
        {
            await Shell.Current.GoToAsync("//main/section/GamesPage");
        }

        // Navigation
        async public void goToPlayers()
        {
            await Shell.Current.GoToAsync("//main/section/PlayersPage");
        }
    }
}
