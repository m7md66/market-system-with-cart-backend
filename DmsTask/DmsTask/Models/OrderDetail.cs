using System.ComponentModel.DataAnnotations.Schema;

namespace DmsTask.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Item { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public int UOM { get; set; }
        public int Tax { get; set; }
        public int Discount { get; set; }


        // relation with order header
        [ForeignKey(nameof(OrderId))]
        public virtual OrderHeader Order { get; set; }
        
        // relation with items
        [ForeignKey(nameof(Item))]
        public virtual Items ItemObj { get; set; }
        
        // relation with Unit of measure
        //[ForeignKey(nameof(UOM))]
        //public virtual UnitOfMeasure MeasureUnit { get; set; }
    }
}
