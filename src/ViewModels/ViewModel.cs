using src.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace src.ViewModels
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        protected GameService gameService = ServiceLocator.ServiceProvider.GetService<GameService>();
        protected TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();
        protected PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();
        protected ScoreService scoreService = ServiceLocator.ServiceProvider.GetService<ScoreService>();
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
