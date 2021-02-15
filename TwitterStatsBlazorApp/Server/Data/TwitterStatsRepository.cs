using System.Collections.Generic;
using System.Linq;
using TwitterStatsBlazorApp.Server.Interfaces;
using TwitterStatsBlazorApp.Shared;

namespace TwitterStatsBlazorApp.Server.Data
{
    public class TwitterStatsRepository : IDataRepository<TwitterStat>
    {
        private readonly TwitterStatsContext _twitterStatsContext;

        public TwitterStatsRepository(TwitterStatsContext twitterStatsContext)
        {
            _twitterStatsContext = twitterStatsContext;
        }

        public void Add(TwitterStat entity)
        {
            _twitterStatsContext.TwitterStats.Add(entity);
            _twitterStatsContext.SaveChanges();
        }

        public void Delete(TwitterStat entity)
        {
            _twitterStatsContext.TwitterStats.Remove(entity);
            _twitterStatsContext.SaveChanges();
        }

        public TwitterStat Get(string key)
        {
            return _twitterStatsContext.TwitterStats.FirstOrDefault(t => t.Key == key);
        }

        public IEnumerable<TwitterStat> GetAll()
        {
            return _twitterStatsContext.TwitterStats.ToList();
        }

        public void Update(TwitterStat entity)
        {
            var twitterStat = _twitterStatsContext.TwitterStats.Where(t => t.Key == entity.Key).FirstOrDefault();
            twitterStat.Value = entity.Value;
            _twitterStatsContext.SaveChanges();
        }
    }
}
