using ShareInvest.Pages;

namespace ShareInvest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MobileShell();

            Routing.RegisterRoute(nameof(Dashboard), typeof(Dashboard));
        }
    }
}