using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Worker
{
    public class MovieWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public MovieWorker(ILogger<MovieWorker> logger, IServiceProvider serviceProvider/*, IHostApplicationLifetime lifetime*/)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<ApiClient>();

                    await service.SendRate();
                }


                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
