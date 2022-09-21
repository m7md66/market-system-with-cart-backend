using System.ComponentModel.DataAnnotations.Schema;

namespace DmsTask.Models
{
    public class Items
    {
        public Items()
        {
            OrderDetails=new HashSet<OrderDetail>();
        }
        public int Id { get; set; }
        public string Item { get; set; }
        public string Atr1 { get; set; }
        public string Atr2 { get; set; }
        public string Atr3 { get; set; }
        public string Atr4 { get; set; }
        public string Atr5 { get; set; }
        public string Atr6 { get; set; }
        public string Atr7 { get; set; }
        public string Atr8 { get; set; }
        public string Description { get; set; }
        public int Uom_id { get; set; }
        public string Uom { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }

        [ForeignKey(nameof(Uom_id))]
        public virtual UnitOfMeasure unitOfMeasure { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
