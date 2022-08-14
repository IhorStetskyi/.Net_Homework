using DapperLib.DALInterfaceImplementation;
using DapperLib.DALInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DapperLib.InjectionFolder
{
    public class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddSingleton<IConnectionController, ConnectionController>()
                .AddSingleton<IOrderController, OrderController>()
                .AddSingleton<IProductController, ProductController>()
                .BuildServiceProvider();
            return provider;
        }
    }
}
