using DmsTask.Models;
using DmsTask.Persistence.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DmsTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
       
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsController(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrderDetails()
        {
            var orderDetails = await _orderDetailsRepository.GetOrderDetails();
            return Ok(orderDetails);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderDetail(int id)
        {
            var orderDetail = await _orderDetailsRepository.GetOrderDetail(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

    }
}
