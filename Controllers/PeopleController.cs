using InterviewTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace InterviewTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PersonContext _context;


        private readonly ILogger<PeopleController> _logger;

        private readonly IMemoryCache _cache;

        public PeopleController(ILogger<PeopleController> logger, PersonContext context, IMemoryCache cache)
        {
            _logger = logger;
            _context = context;
            _cache = cache;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get(string? filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                string cacheKey = $"PeopleSearch_{filter}";
                if (_cache.TryGetValue(cacheKey, out IEnumerable<Person> cachedResults))
                {
                    return Ok(cachedResults);
                }
                var searchResults = await _context.People.Where(p => p.LastName.ToLower().Contains(filter.ToLower()) || p.FirstName.ToLower().Contains(filter.ToLower())).ToListAsync();

                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                _cache.Set(cacheKey, searchResults, cacheOptions);

                return Ok(searchResults);
            }

            return await _context.People.ToListAsync();
        }
    }
}
