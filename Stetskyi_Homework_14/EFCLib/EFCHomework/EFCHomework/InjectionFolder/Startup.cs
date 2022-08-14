using EFCHomework.Controllers;
using EFCHomework.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EFCHomework.InjectionFolder
{
    public class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddSingleton<ApplicationDbContext>()
                .AddSingleton<DbContextOptionsBuilder>()
                .AddSingleton<ModelBuilder>()
                .AddSingleton<OrderController>()
                .AddSingleton<ProductController>()
                .BuildServiceProvider();
            return provider;
        }
    }
}
