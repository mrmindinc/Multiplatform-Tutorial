namespace ShareInvest.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        public Task InitializeAsync()
        {
            

            return Task.CompletedTask;
        }
        public DashboardViewModel(DashboardService service)
        {
            this.service = service;
        }
        readonly DashboardService service;
    }
}