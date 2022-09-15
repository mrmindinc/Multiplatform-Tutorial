﻿using DevExpress.Maui;

using Microsoft.Maui.Controls.Compatibility.Hosting;

using ShareInvest.ViewModels;

namespace ShareInvest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .UseMauiCompatibility()
                .ConfigureEssentials(essentials =>
                {
                    essentials.UseVersionTracking();
                })
                .ConfigureServices()
                .ConfigureViewModels()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                });
            return builder.Build();
        }
    }
}