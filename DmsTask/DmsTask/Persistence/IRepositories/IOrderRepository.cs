using DmsTask.Models;
using DmsTask.Resource.Order;

namespace DmsTask.Persistence.IRepositories
{
    public interface IOrderRepository
    {
        Task Add(OrderDto orderViewModel);
        List<OrderResponseDto> GetOrders();
        //List<OrderDetail> GetOrders();

    }
}
