namespace src
{
    public partial class PlayersPage : ContentPage
    {

        public PlayersPage()
        {
            InitializeComponent();

            BindingContext = ServiceLocator.ServiceProvider.GetService<ViewModels.PlayersViewModel>();
        }

    }

}
