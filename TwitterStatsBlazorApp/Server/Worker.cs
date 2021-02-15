using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterStatsBlazorApp.Server.Hubs;
using TwitterStatsBlazorApp.Server.Interfaces;
using TwitterStatsBlazorApp.Shared;

namespace TwitterStatsBlazorApp.Server
{
    public class Worker : IWorker
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IWorkerHelper _workerHelper;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(ILogger logger, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory, IWorkerHelper workerHelper)
        {
            _logger = logger;
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            _workerHelper = workerHelper;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var twitterStatsRepository = scope.ServiceProvider.GetService<IDataRepository<TwitterStat>>();
            var hubContext = scope.ServiceProvider.GetService<IHubContext<BroadcastHub>>();

            while (!cancellationToken.IsCancellationRequested)
            {
                var appCredentials = new ConsumerOnlyCredentials(_configuration["TwitterKey"], _configuration["TwitterSecret"])
                {
                    BearerToken = _configuration["TwitterBearerToken"]
                };

                var appClient = new TwitterClient(appCredentials);
                var sampleStreamV2 = appClient.StreamsV2.CreateSampleStream();
                var totalTweets = 0;
                var stopWatch = new Stopwatch();
                //var currentMinute = 0;

                stopWatch.Start();

                sampleStreamV2.TweetReceived += async (sender, args) =>
                {
                    if (args.Tweet != null)
                    {
                        //var tweet = args.Tweet;                    
                        //_logger.LogInformation(args.Tweet.Text);
                        totalTweets++;
                        var ts = stopWatch.Elapsed;

                        var elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                        (var urlPercentage, var picPercentage, var topDomainsDictionary) = _workerHelper.GetUrlStats(args.Tweet, totalTweets);

                        var counters = new Counters
                        {
                            ElapsedTime = elapsedTime,
                            TotalNumberOfTweets = totalTweets,
                            AverageTweetsPerHour = _workerHelper.CalculateAverageTweetsPerHour((int)ts.TotalHours, totalTweets),
                            AverageTweetsPerMinute = _workerHelper.CalculateAverageTweetsPerMinute((int)ts.TotalMinutes, totalTweets),
                            AverageTweetsPerSecond = _workerHelper.CalculateAverageTweetsPerSecond((int)ts.TotalSeconds, totalTweets),
                            TopHashtags = _workerHelper.GetTopHashtags(args.Tweet),
                            PercentageOfTweetsWithUrl = urlPercentage,
                            PercentageOfTweetsWithPic = picPercentage,
                            TopDomains = topDomainsDictionary,
                            TopEmojis = _workerHelper.GetTopEmojis(args.Tweet)
                        };

                        //TODO: throttle updating database
                        //TODO: use redis caching?
                        //TODO: database schema needs work
                        //if (currentMinute < totalMins)
                        //{
                        //    
                        //    currentMinute = totalMins;

                        //twitterStatsRepository.Update(new TwitterStat { Key = Enum.GetName(DbKeys.TotalNumberOfTweets), Value = totalTweets.ToString() });
                        //twitterStatsRepository.Update(new TwitterStat { Key = Enum.GetName(DbKeys.AverageTweetsPerHour), Value = avgPerHr.ToString() });
                        //twitterStatsRepository.Update(new TwitterStat { Key = Enum.GetName(DbKeys.AverageTweetsPerMinute), Value = avgPerMin.ToString() });
                        //twitterStatsRepository.Update(new TwitterStat { Key = Enum.GetName(DbKeys.AverageTweetsPerSecond), Value = avgPerSec.ToString() });

                        //}

                        await hubContext.Clients.All.SendAsync("ReceiveMessage", counters);
                    }
                };

                await sampleStreamV2.StartAsync();
            }
        }
    }
}
