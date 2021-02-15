using System.ComponentModel.DataAnnotations;

namespace TwitterStatsBlazorApp.Shared
{
    public class TwitterStat
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
