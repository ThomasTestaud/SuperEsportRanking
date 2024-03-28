using src.Services;
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

            services.AddSingleton<ViewModels.GamesViewModel>();
            services.AddSingleton<ViewModels.PlayersViewModel>();
            services.AddSingleton<ViewModels.ScoresViewModel>();

            services.AddSingleton<Services.GameService>();
            services.AddSingleton<Services.PlayerService>();
            services.AddSingleton<Services.TeamService>();
            services.AddSingleton<Services.ScoreService>();

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


            TeamWithPlayers teamWithPlayers = teamService.GetTeam(team1.id);
            List<Player> players = teamWithPlayers.players;

            gameService.AddTeamGame("Game 1", DateTime.Now, players, 10);
            gameService.AddTeamGame("Game 2", DateTime.Now, players, 5);
        }
    }
}
