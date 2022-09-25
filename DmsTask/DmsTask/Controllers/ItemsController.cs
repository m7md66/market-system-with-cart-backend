using DmsTask.Models;
using DmsTask.Persistence;
using DmsTask.Persistence.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DmsTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;

        public ItemsController(DmsContext dmsTask, IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Getitems()
        {
           var items =await _itemsRepository.Getitems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(int id)
        {
            var item = await _itemsRepository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Items>> AddItem(Items item)
        {
           var result=await _itemsRepository.AddItem(item);
            if (result == 1) { return Ok(); }
            else { return Problem("some error"); }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _itemsRepository.DeleteItem(id);
            if (result == 1) { return Ok(); }
            else
            {
                return Problem("some error");
            }
        }
    }
}
