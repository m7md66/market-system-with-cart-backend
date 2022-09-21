using System.ComponentModel.DataAnnotations.Schema;

namespace DmsTask.Models
{
    public class OrderHeader
    {
        public OrderHeader() 
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string Customer { get; set; }
        public int TaxCode { get; set; }
        public float TaxValue { get; set; }
        public int DiscountCode { get; set; }
        public float DiscountValue { get; set; }
        public float TotalPrice { get; set; }

        // relation with App user
        [ForeignKey(nameof(Customer))]
        public virtual AppUser UserCustomer { get; set; }

        //relation with order details
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
