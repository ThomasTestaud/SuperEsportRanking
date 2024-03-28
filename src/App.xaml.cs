using src.Services;
using src.ViewModels;
using src.Models;

namespace src
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<GamesViewModel>();
            services.AddSingleton<PlayersViewModel>();
            services.AddSingleton<ScoresViewModel>();

            services.AddSingleton<GameService>();
            services.AddSingleton<PlayerService>();
            services.AddSingleton<TeamService>();
            services.AddSingleton<ScoreService>();

            var serviceProvider = services.BuildServiceProvider();

            ServiceLocator.Initialize(serviceProvider);

            // Populate the database with some data
            GameService gameService = ServiceLocator.ServiceProvider.GetService<GameService>();
            TeamService teamService = ServiceLocator.ServiceProvider.GetService<TeamService>();
            PlayerService playerService = ServiceLocator.ServiceProvider.GetService<PlayerService>();

            Team team1 = teamService.AddTeam("Team 1");
            Team team2 = teamService.AddTeam("Team 2");

            playerService.AddPlayer("Player 1", "player1", team1.id);
            playerService.AddPlayer("Player 2", "player2", team1.id);

            playerService.AddPlayer("Player 3", "player3", team2.id);
            playerService.AddPlayer("Player 4", "player4", team2.id);


            TeamWithPlayers teamWithPlayers = teamService.GetTeam(team1.id);
            List<Player> players = teamWithPlayers.players;

            //gameService.AddGame("Game 1", DateTime.Now, players, 10);
            //gameService.AddGame("Game 2", DateTime.Now, players, 5);
        }
    }
}
