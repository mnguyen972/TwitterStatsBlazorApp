using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tweetinvi.Models.V2;
using TwitterStatsBlazorApp.Server.Interfaces;

namespace TwitterStatsBlazorApp.Server.Helpers
{
    public class WorkerHelper : IWorkerHelper
    {
        private Dictionary<string, string> EmojiDictionary;
        private Regex EmojiRegex;
        //TODO: use ConcurrentDictionary instead?
        private SortedDictionary<string, long> TopHashtagsDictionary = new SortedDictionary<string, long>();
        private SortedDictionary<string, long> TopDomainsDictionary = new SortedDictionary<string, long>();
        private SortedDictionary<string, long> TopEmojisDictionary = new SortedDictionary<string, long>();
        private int TotalTweetsWithUrl = 0;
        private int TotalTweetsWithPic = 0;

        public WorkerHelper()
        {
            LoadEmojiFile();
        }

        public (bool, string, string) IsDomain(string url)
        {
            Regex regex =
                new Regex(
                    @"([a-z0-9A-Z]\.)*[a-z0-9-]+\.([a-z0-9]{2,24})+(\.co\.([a-z0-9]{2,24})|\.([a-z0-9]{2,24}))*",
                    RegexOptions.Compiled);
            bool isValid = regex.IsMatch(url);

            string dom = "";
            string domainTLD = "";
            if (isValid)
            {
                Match match = regex.Match(url);
                dom = match.Value.Replace("www.", "");
                string[] splitedDomain = dom.Trim().Split('.');
                int splitedDomainLength = splitedDomain.Length;
                int tld = splitedDomainLength - 1;
                domainTLD = splitedDomain[tld];
            }
            return (isValid, dom, domainTLD);
        }

        public int CalculateAverageTweetsPerMinute(int totalMinutes, int totalTweets)
        {
            return totalMinutes != 0 ? totalTweets / totalMinutes : 0;
        }

        public int CalculateAverageTweetsPerHour(int totalHours, int totalTweets)
        {
            return totalHours != 0 ? totalTweets / totalHours : 0;
        }

        public int CalculateAverageTweetsPerSecond(int totalSeconds, int totalTweets)
        {
            return totalSeconds != 0 ? totalTweets / totalSeconds : 0;
        }

        private void LoadEmojiFile()
        {
            var data = JArray.Parse(File.ReadAllText("emoji.json"));
            EmojiDictionary = data.OfType<JObject>().ToDictionary(
                c => ((JValue)c["short_name"]).Value.ToString(),
                c => {
                    var unicodeRaw = ((JValue)c["unified"]).Value.ToString();
                    var chars = new List<char>();
                    foreach (var point in unicodeRaw.Split('-'))
                    {
                        uint unicodeInt = uint.Parse(point, System.Globalization.NumberStyles.HexNumber);
                        chars.AddRange(Encoding.UTF32.GetChars(BitConverter.GetBytes(unicodeInt)));
                    }
                    return new string(chars.ToArray());
                });
            EmojiRegex = new Regex(string.Join("|", EmojiDictionary.Values.Select(Regex.Escape)));
        }

        public List<KeyValuePair<string, long>> GetTopHashtags(TweetV2 tweet)
        {
            tweet?.Entities?.Hashtags?.Distinct().ToList().ForEach(h =>
            {
                if (TopHashtagsDictionary.TryGetValue(h.Tag, out var count))
                {
                    TopHashtagsDictionary[h.Tag] = count + 1;
                }
                else
                {
                    TopHashtagsDictionary.TryAdd(h.Tag, 1);
                }
            });

            return TopHashtagsDictionary.OrderByDescending(i => i.Value).Take(10).ToList();
        }

        public List<KeyValuePair<string, long>> GetTopDomains()
        {
            return TopDomainsDictionary.OrderByDescending(i => i.Value).Take(10).ToList();
        }

        public List<KeyValuePair<string, long>> GetTopEmojis(TweetV2 tweet)
        {
            var emojiMatches = EmojiRegex.Matches(tweet.Text);
            emojiMatches.ToList().ForEach(e =>
            {
                if (TopEmojisDictionary.TryGetValue(e.ToString(), out var count))
                {
                    TopEmojisDictionary[e.ToString()] = count + 1;
                }
                else
                {
                    TopEmojisDictionary.TryAdd(e.ToString(), 1);
                }
            });

            return TopEmojisDictionary.OrderByDescending(i => i.Value).Take(10).ToList();
        }

        public (int, int, List<KeyValuePair<string, long>>) GetUrlStats(TweetV2 tweet, int totalTweets)
        {
            var picFlag = false;
            if (tweet?.Entities?.Urls?.Length > 0)
            {
                TotalTweetsWithUrl++;

                tweet?.Entities?.Urls?.Distinct().ToList().ForEach(u =>
                {
                    var (isDomain, domain, domainTLD) = IsDomain(u.Url);
                    if (isDomain)
                    {
                        if (TopDomainsDictionary.TryGetValue(domain, out var count))
                        {
                            TopDomainsDictionary[domain] = count + 1;
                        }
                        else
                        {
                            TopDomainsDictionary.TryAdd(domain, 1);
                        }

                        if (picFlag == false && (domain.Contains("pic.twitter.com") || domain.Contains("instagram")))
                        {
                            picFlag = true;
                            TotalTweetsWithPic++;
                        }
                    }
                });
            }
            var urlPercentage = (int)Math.Round(TotalTweetsWithUrl / (double)totalTweets * 100, 0, MidpointRounding.AwayFromZero);
            var picPercentage = (int)Math.Round(TotalTweetsWithPic / (double)totalTweets * 100, 0, MidpointRounding.AwayFromZero);

            return (urlPercentage, picPercentage, TopDomainsDictionary.OrderByDescending(i => i.Value).Take(10).ToList());
        }
    }
}
