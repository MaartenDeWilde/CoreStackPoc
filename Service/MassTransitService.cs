using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Service.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public class MassTransitService : IHostedService
    {
        private readonly IConfigurationRoot configuration;
        private IBusControl _busControl;

        public MassTransitService(IConfigurationRoot configuration)
        {
            this.configuration = configuration;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(configuration.GetConnectionString("RabbitMQ"));
                cfg.ReceiveEndpoint("BgService", e =>
                {
                    e.Consumer<CreateInvoiceFileConsumer>();
                });
            });

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await _busControl.StartAsync(source.Token);
            Console.WriteLine("Running");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _busControl.StopAsync();
        }
    }
}
