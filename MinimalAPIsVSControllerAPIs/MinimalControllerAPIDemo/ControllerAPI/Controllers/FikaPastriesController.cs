using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControllerAPI.Database;
using ControllerAPI.Models;

namespace ControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FikaPastriesController : ControllerBase
    {
        private readonly FikaDbContext _context;

        public FikaPastriesController(FikaDbContext context)
        {
            _context = context;
        }

        // GET: api/fikapastries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FikaPastry>>> GetFikaPastries()
        {
            return await _context.FikaPastries.ToListAsync();
        }

        // GET: api/fikapastries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FikaPastry>> GetFikaPastry(int id)
        {
            var pastry = await _context.FikaPastries.FindAsync(id);
            if (pastry == null)
            {
                return NotFound();
            }
            return pastry;
        }

        // POST: api/fikapastries
        [HttpPost]
        public async Task<ActionResult<FikaPastry>> PostFikaPastry(FikaPastry pastry)
        {
            _context.FikaPastries.Add(pastry);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFikaPastry), new { id = pastry.Id }, pastry);
        }

        // PUT: api/fikapastries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFikaPastry(int id, FikaPastry pastry)
        {
            if (id != pastry.Id)
            {
                return BadRequest();
            }

            _context.Entry(pastry).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/fikapastries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFikaPastry(int id)
        {
            var pastry = await _context.FikaPastries.FindAsync(id);
            if (pastry == null)
            {
                return NotFound();
            }

            _context.FikaPastries.Remove(pastry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
