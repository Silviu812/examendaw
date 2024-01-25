using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace app_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(AppDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> GetUtilizatori()
        {
            _logger.LogInformation("Fetching all users");
            return _context.Utilizatori.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<User> GetUtilizator(int id)
        {
            var utilizator = _context.Utilizatori.Find(id);

            if (utilizator == null)
            {
                _logger.LogInformation($"User with id {id} not found.");
                return NotFound();
            }

            return utilizator;
        }

    }
}
