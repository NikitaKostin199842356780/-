using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thetasksApi.Models;
namespace thetasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class thetasksController : ControllerBase
    {
        private readonly thetasksContext _context;
        public thetasksController(thetasksContext context)
        {
            _context = context;
            if (_context.thetasksItems.Count() == 0)
            {
                
                _context.thetasksItems.Add(new thetasksItem
                {
                    Name = "The-tasks"
                });
                _context.SaveChanges();
            }
        }
        // GET: api/thetasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<thetasksItem>>> GetthetasksItems()
        {
            return await _context.thetasksItems.ToListAsync();
        }
        // GET: api/thetasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<thetasksItem>> GetthetasksItem(long id)
        {
            var thetasksItem = await _context.thetasksItems.FindAsync(id);
            if (thetasksItem == null)
            {
                return NotFound();
            }
            return thetasksItem;

        }
       
        [HttpPost]
        public async Task<ActionResult<thetasksItem>> PostthetasksItem(thetasksItem item)
        {
            _context.thetasksItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetthetasksItem), new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutthetasksItem(long id, thetasksItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // DELETE: api/thetasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletethetasksItem(long id)
        {
            var thetasksItem = await _context.thetasksItems.FindAsync(id);
            if (thetasksItem == null)
            {
                return NotFound();
            }
            _context.thetasksItems.Remove(thetasksItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}