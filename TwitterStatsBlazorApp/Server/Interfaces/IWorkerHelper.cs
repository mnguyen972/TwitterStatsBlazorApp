using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;

namespace TwitterStatsBlazorApp.Server.Interfaces
{
    public interface IWorkerHelper
    {
        public (bool isDomain, string domain, string domainTLD) IsDomain(string url);
        public int CalculateAverageTweetsPerMinute(int totalMinutes, int totalTweets);
        public int CalculateAverageTweetsPerHour(int totalHours, int totalTweets);
        public int CalculateAverageTweetsPerSecond(int totalSeconds, int totalTweets);
        public List<KeyValuePair<string, long>> GetTopHashtags(TweetV2 tweet);
        public (int, int, List<KeyValuePair<string, long>>) GetUrlStats(TweetV2 tweet, int totalTweets);
        public List<KeyValuePair<string, long>> GetTopEmojis(TweetV2 tweet);

    }
}
