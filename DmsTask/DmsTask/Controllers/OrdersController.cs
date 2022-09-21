using DmsTask.Data;
using DmsTask.Models;
using DmsTask.ViewModels;
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
        public async Task<IActionResult> AddOrder([FromBody] OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                await orderRepository.Add(orderViewModel);
                     return Ok();
        }
        [HttpGet("GetOrders")]
        public  IActionResult GetOrders()
        {
            
          var list=
                context.OrderDetails
                .Select(q => new {Customer=q.Order.UserCustomer.CustomerDescription, OrderDate= q.Order.OrderDate, ItemName=q.ItemObj.Item,ItemPrice=q.ItemObj.Price,quantity=q.Quantity,UOM=q.ItemObj.unitOfMeasure.UOM ,Discount=q.Discount }).ToList();
            if (list == null)
            {
                return NotFound("List is empty");
            }
            return Ok(list);


        }




    }
}
