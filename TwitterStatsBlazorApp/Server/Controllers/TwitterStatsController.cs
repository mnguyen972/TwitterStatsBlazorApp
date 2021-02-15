using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterStatsBlazorApp.Server.Interfaces;
using TwitterStatsBlazorApp.Shared;

namespace TwitterStatsBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterStatsController : ControllerBase
    {
        private readonly IDataRepository<TwitterStat> _twitterStatsRepository;

        public TwitterStatsController(IDataRepository<TwitterStat> twitterStatsRepository)
        {
            _twitterStatsRepository = twitterStatsRepository;
        }

        // GET: api/TwitterStats
        [HttpGet]
        public IEnumerable<TwitterStat> GetTwitterStats()
        {
            return _twitterStatsRepository.GetAll();
        }
    }
}
