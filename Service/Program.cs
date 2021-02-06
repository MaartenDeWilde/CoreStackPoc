using MassTransit;
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
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumers(typeof(CreateInvoiceFileConsumer).Assembly);
                        x.UsingRabbitMq((context, cfg) =>
                         {
                             cfg.Host(hostContext.Configuration.GetConnectionString("RabbitMq"));
                             cfg.ReceiveEndpoint("BgService", e =>
                             {
                                 e.ConfigureConsumer<CreateInvoiceFileConsumer>(context);
                             });
                         });
                    });
                    services.AddHostedService<MassTransitService>();
                });
    }
}
