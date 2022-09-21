using DmsTask.Models;
using DmsTask.ViewModels;

namespace DmsTask.Data
{
    public interface IOrderRepository
    {
       Task Add(OrderViewModel orderViewModel);
        //List<OrderResponseViewModel> GetOrders();
        //List<OrderDetail> GetOrders();

    }
}
