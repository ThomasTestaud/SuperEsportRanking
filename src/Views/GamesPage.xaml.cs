

namespace src
{
    public partial class GamesPage : ContentPage
    {

        public GamesPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.GamesViewModel();
        }

    }

}
