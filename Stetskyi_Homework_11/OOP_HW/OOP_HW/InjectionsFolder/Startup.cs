using Microsoft.Extensions.DependencyInjection;
using OOP_HW.Interfaces;
using OOP_HW.DataSources;
using OOP_HW.UiProvider;
using OOP_HW.Application;
using System;


namespace OOP_HW.InjectionsFolder
{
    class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddSingleton<ISource, FileDataSource>()
                .AddSingleton<IUiProvider, ConsoleUi>()
                .AddSingleton<IApplication, LibraryApplication>()
                .AddMemoryCache()
                .BuildServiceProvider();
            return provider;
        }
    }
}
