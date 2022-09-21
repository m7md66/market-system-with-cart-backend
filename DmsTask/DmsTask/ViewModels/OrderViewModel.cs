using DmsTask.Models;

namespace DmsTask.ViewModels
{
    public class OrderViewModel 
    {
        public string Customer_Id { get; set; }
        public float TotalPrice { get; set; }
        public  ICollection<Items> items { get; set; }

    }
}
