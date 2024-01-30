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

            services.AddSingleton<Models.Game>();
            services.AddSingleton<Models.Player>();
            services.AddSingleton<Models.Team>();

            var serviceProvider = services.BuildServiceProvider();
            ServiceLocator.Initialize(serviceProvider);

            //var gameService = ServiceLocator.ServiceProvider.GetService<Services.GameService>();

        }
    }
}
