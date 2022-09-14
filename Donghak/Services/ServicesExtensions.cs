namespace ShareInvest.Services
{
    public static class ServicesExtensions
    {
        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<DashboardService>();

            return builder;
        }
    }
}