using DmsTask.Data;
using DmsTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DmsTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ItemsController : ControllerBase
    {
        private readonly DmsContext _context;

        public ItemsController(DmsContext dmsTask)
        {
            _context = dmsTask;
        }

        [HttpGet]
        public async Task<ActionResult> Getitems()
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            return Ok(await _context.Items.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(int id)
        {
            if (_context.Items == null)
            {
                return Unauthorized();
            }
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Items>> AddItem(Items item)
        {
            _context.Items.Add(item);
            var result = await _context.SaveChangesAsync();
            if (result == 1) { return Ok(); }
            else { return Problem("some error"); }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Items.Remove(item);
            var result = await _context.SaveChangesAsync();
            if (result == 1) { return Ok(); }
            else
            {
                return Problem("some error");
            }

        }
    }
}
