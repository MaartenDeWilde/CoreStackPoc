using System;
using MassTransit;
using System.Threading;
using System.Threading.Tasks;
using Service.Handlers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Logic.DI;

namespace Service
{
    class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddServices();
                    services.AddHostedService<MassTransitService>();
                });
    }
}
