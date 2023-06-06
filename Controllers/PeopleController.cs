using InterviewTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PersonContext _context;
      

        private readonly ILogger<PeopleController> _logger;

        public PeopleController(ILogger<PeopleController> logger, PersonContext context) { 
            _logger = logger;
            _context = context; 
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get(string? filter)
        {
            if(!string.IsNullOrEmpty(filter))
            {
                return await _context.People.Where(p => p.LastName.ToLower().Contains(filter.ToLower()) || p.FirstName.ToLower().Contains(filter.ToLower())).ToListAsync();
            }
            
            return await _context.People.ToListAsync();
        }
    }
}
