using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace app_api
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
                return BadRequest();
            }

            return utilizator;
        }
        [HttpPost]
        public async Task<ActionResult<User>> AdaugaUtilizator(User utilizator)
        {
            _context.Utilizatori.Add(utilizator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizator", new { id = utilizator.Id }, utilizator);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUtilizator(int id, User utilizator)
        {
            if (id != utilizator.Id)
            {
                return BadRequest();
            }

            _context.Entry(utilizator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        private bool UtilizatorExists(int id)
        {
            return _context.Utilizatori.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilizator(int id)
        {
            var utilizator = await _context.Utilizatori.FindAsync(id);
            if (utilizator == null)
            {
                return NotFound();
            }

            _context.Utilizatori.Remove(utilizator);
            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}
