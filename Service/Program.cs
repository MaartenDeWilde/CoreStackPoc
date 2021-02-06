using System;
using MassTransit;
using System.Threading;
using System.Threading.Tasks;
using Service.Handlers;

namespace Service
{
    class Program
    {

        public static async Task Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host("rabbitmq://192.168.0.121:32773");
                cfg.ReceiveEndpoint("BgService", e =>
                {
                    e.Consumer<CreateInvoiceFileConsumer>();
                });
            });

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await busControl.StartAsync(source.Token);
            try
            {
                Console.WriteLine("Press enter to exit");

                await Task.Run(() => Console.ReadLine());
            }
            finally
            {
                await busControl.StopAsync();
            }
        }

        



    }
}
