using ADOClassLibrary.Interfaces;
using ADOClassLibrary.ConnectionProviderFolder;
using ADOClassLibrary.PerformerFolder;
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
                .AddSingleton<IConnectionProvider, ConnectionProvider>()
                .AddSingleton<IPerformer, Performer>()
                .AddSingleton<IProductPerformer, ProductPerformer>()
                .AddSingleton<IOrderPerformer, OrderPerformer>()
                .BuildServiceProvider();
            return provider;
        }
    }
}
