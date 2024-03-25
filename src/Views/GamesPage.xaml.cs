

namespace src
{
    public partial class GamesPage : ContentPage
    {

        public GamesPage()
        {
            InitializeComponent();

            BindingContext = ServiceLocator.ServiceProvider.GetService<ViewModels.GamesViewModel>();
        }

    }

}
