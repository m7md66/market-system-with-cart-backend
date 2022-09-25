using DmsTask.Models;
using DmsTask.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DmsTask.Persistence.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly DmsContext _DbContext;
        public OrderDetailsRepository(DmsContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {

            return await _DbContext.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetail(int id)
        {
            //if (_DbContext.OrderDetails == null)
            //{
            //    return NotFound();
            //}
            var orderDetail = await _DbContext.OrderDetails.FindAsync(id);

            return orderDetail;
        }
    }
}
