using DmsTask.Models;

namespace DmsTask.Persistence.IRepositories
{
    public interface IOrderDetailsRepository
    {
        public Task<IEnumerable<OrderDetail>> GetOrderDetails();
        public Task<OrderDetail> GetOrderDetail(int id);


    }
}
