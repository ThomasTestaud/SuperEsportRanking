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
        }
    }
}
