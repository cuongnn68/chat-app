using System;
using DRApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DRApp
{
    public class DI
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ITestService, TestService>();
            
            Console.WriteLine(services.Count);
            
            // var servicesProvider = new ServiceCollection()
            //     .AddSingleton<ITestService, TestService>()
            //     .BuildServiceProvider();
            ServiceProvider = services.BuildServiceProvider();

            return ServiceProvider;
        }

        // public static IServiceProvider ConfigureServices(this IServiceProvider services)
        // {
        //     
        //
        //     return services;
        // }
    }
}