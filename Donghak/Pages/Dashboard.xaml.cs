using ShareInvest.ViewModels;

namespace ShareInvest.Pages
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard(DashboardViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.InitializeAsync();
        }
        DashboardViewModel viewModel => BindingContext as DashboardViewModel;
    }
}