

namespace src
{
    public partial class GamesPage : ContentPage
    {

        public GamesPage()
        {
            InitializeComponent();
            //BindingContext = new ViewModels.GamesViewModel();
            BindingContext = ServiceLocator.ServiceProvider.GetService<ViewModels.GamesViewModel>();
        }

    }

}
