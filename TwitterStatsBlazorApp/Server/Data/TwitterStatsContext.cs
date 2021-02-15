using Microsoft.EntityFrameworkCore;
using System;
using TwitterStatsBlazorApp.Shared;

namespace TwitterStatsBlazorApp.Server.Data
{
    public class TwitterStatsContext : DbContext
    {
        public TwitterStatsContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TwitterStat> TwitterStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TwitterStat>().HasData(
            new TwitterStat
            {
                Key = Enum.GetName(DbKeys.TotalNumberOfTweets),
                Value = "0"
            },
            new TwitterStat
            {
                Key = Enum.GetName(DbKeys.AverageTweetsPerHour),
                Value = "0"
            },
            new TwitterStat
            {
                Key = Enum.GetName(DbKeys.AverageTweetsPerMinute),
                Value = "0"
            },
            new TwitterStat
            {
                Key = Enum.GetName(DbKeys.AverageTweetsPerSecond),
                Value = "0"
            });
        }
    }
}
