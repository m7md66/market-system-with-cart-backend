using DmsTask.Models;

namespace DmsTask.Resource.Order
{
    public class OrderDto
    {
        public string Customer_Id { get; set; }
        public float TotalPrice { get; set; }
        public ICollection<Items> items { get; set; }

    }
}
