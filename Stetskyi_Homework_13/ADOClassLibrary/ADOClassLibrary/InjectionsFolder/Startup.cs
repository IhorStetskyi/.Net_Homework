using ADOClassLibrary.Interfaces;
using ADOClassLibrary.ConnectionProviderFolder;
using Microsoft.Extensions.DependencyInjection;
using System;
using ADOClassLibrary.InterfaceImplementationFolder;

namespace ADOClassLibrary.InjectionsFolder
{
    public static class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddSingleton<IConnectionController, ConnectionController>()
                .AddSingleton<IProductPerformer, ProductPerformer>()
                .AddSingleton<IOrderPerformer, OrderPerformer>()
                .BuildServiceProvider();
            return provider;
        }
    }
}
