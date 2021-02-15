using System.Collections.Generic;

namespace TwitterStatsBlazorApp.Shared
{
    public class Counters
    {
        public string ElapsedTime { get; set; }
        public int TotalNumberOfTweets { get; set; }
        public int AverageTweetsPerHour { get; set; }
        public int AverageTweetsPerMinute { get; set; }
        public int AverageTweetsPerSecond { get; set; }
        public List<KeyValuePair<string, long>> TopHashtags { get; set; }
        public int PercentageOfTweetsWithUrl { get; set; }
        public int PercentageOfTweetsWithPic { get; set; }
        public List<KeyValuePair<string, long>> TopDomains { get; set; }
        public List<KeyValuePair<string, long>> TopEmojis { get; set; }
    }
}
