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
            
            Team team1 = teamService.Add(new Team("Team 1"));
            Team team2 = teamService.Add(new Team("Team 2"));
            Player player1 = playerService.Add(new Player("Player 1", "player1", team1.id));
            Player player2 = playerService.Add(new Player("Player 2", "player2", team1.id));

            playerService.Add(new Player("Player 3", "player3", team2.id));
            playerService.Add(new Player("Player 4", "player4", team2.id));


            TeamWithPlayers teamWithPlayers = teamService.GetTeamWithPlayers(team1.id);
            List<Player> players = teamWithPlayers.players;


            gameService.Add(new Game("Game 1", DateTime.Now,  1, 2, true, team1.name, team2.name));
            gameService.Add(new Game("Game 2", DateTime.Now,  3, 4, true, team1.name, team2.name));
            gameService.Add(new Game("Game 3", DateTime.Now,  5, 6, false, player2.name, player1.name));
            gameService.Add(new Game("Game 4", DateTime.Now,  7, 8, false, player2.name, player1.name));
            gameService.Add(new Game("Game 5", DateTime.Now,  9, 10, true, team1.name, team2.name));
            gameService.Add(new Game("Game 6", DateTime.Now,  11, 12, true, team1.name, team2.name));
        }
    }
}
