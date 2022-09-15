namespace ShareInvest.ViewModels
{
    public static class ViewModelExtensions
    {
        public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<DashboardViewModel>();

            return builder;
        }
    }
}