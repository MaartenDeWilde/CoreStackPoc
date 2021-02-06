using Logic.DI;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public class MassTransitService : IHostedService
    {
        private IBusControl _busControl;

        public MassTransitService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await _busControl.StartAsync(source.Token);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _busControl.StopAsync();
        }
    }
}
