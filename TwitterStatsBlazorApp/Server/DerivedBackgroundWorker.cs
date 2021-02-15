using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterStatsBlazorApp.Server.Interfaces;

namespace TwitterStatsBlazorApp.Server
{
    public class DerivedBackgroundWorker : BackgroundService
    {
        private readonly IWorker _worker;
        private readonly ILogger _logger;

        public DerivedBackgroundWorker(IWorker worker, ILogger logger)
        {
            _worker = worker;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await _worker.DoWork(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Exception in DerivedBackgroundWorker");
            }
        }
    }
}