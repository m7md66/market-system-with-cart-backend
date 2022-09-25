using DmsTask.Models;
using DmsTask.Persistence;
using DmsTask.Persistence.IRepositories;
using DmsTask.Resource.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DmsTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly DmsContext context;

        public OrdersController(IOrderRepository orderRepository, DmsContext context)
        {
            this.orderRepository = orderRepository;
            this.context = context;
        }


        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddOrder([FromBody] OrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                await orderRepository.Add(orderDto);
                     return Ok();
        }

        [HttpGet("GetOrders")]
        public  IActionResult GetOrders()
        {
            var orders = orderRepository.GetOrders();
         
            if (orders == null)
            {
                return NotFound("List is empty");
            }
            return Ok(orders);
        }




    }
}
