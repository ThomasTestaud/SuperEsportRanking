using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace src.ViewModels
{
    internal class ScoresViewModel : ViewModel
    {
        public ICommand goToGamesCommand { get; }
        public ICommand goToPlayersCommand { get; }

        public ScoresViewModel()
        {
            goToGamesCommand = new Command(goToGames);
            goToPlayersCommand = new Command(goToPlayers);
        }

        async public void goToGames()
        {
            await Shell.Current.GoToAsync("//main/section/GamesPage");
        }

        async public void goToPlayers()
        {
            await Shell.Current.GoToAsync("//main/section/PlayersPage");
        }
    }
}
