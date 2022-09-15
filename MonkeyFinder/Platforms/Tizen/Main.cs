using Microsoft.Maui;
using Microsoft.Maui.Hosting;

using System;

namespace MindMap
{
    class Program : MauiApplication
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}