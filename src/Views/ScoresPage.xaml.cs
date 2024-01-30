namespace src
{
    public partial class ScoresPage : ContentPage
    {

        public ScoresPage()
        {
            InitializeComponent();

            BindingContext = ServiceLocator.ServiceProvider.GetService<ViewModels.ScoresViewModel>();
        }

    }

}
