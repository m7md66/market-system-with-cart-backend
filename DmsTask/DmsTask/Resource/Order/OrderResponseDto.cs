namespace DmsTask.Resource.Order
{
    public class OrderResponseDto
    {
        //public string Item { get; set; }
        //public float TotalPrice { get; set; }
        //public string UOM { get; set; }
        //public string customerName { get; set; }

        public string CustomerDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public string Item { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string UOM { get; set; }
        public float Discount { get; set; }
     

    }
}


//Customer = q.Order.UserCustomer.CustomerDescription,
//    OrderDate = q.Order.OrderDate,
//    ItemName = q.ItemObj.Item
//    ,ItemPrice = q.ItemObj.Price
//    ,quantity = q.Quantity,
//    UOM = q.ItemObj.unitOfMeasure.UOM 
//    ,Discount = q.Discount 
//    }).ToList();