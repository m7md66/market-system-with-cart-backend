using DmsTask.Models;
using DmsTask.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DmsTask.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DmsContext context;

 
        public OrderRepository(DmsContext context)
        {
            this.context = context;
        }
        public async Task Add(OrderViewModel orderViewModel)
        {
            OrderHeader orderHeader = new OrderHeader();
            orderHeader.OrderDate = DateTime.Now;
            orderHeader.RequestDate = DateTime.Now;
            orderHeader.DueDate = DateTime.Now;
            orderHeader.Customer = orderViewModel.Customer_Id;
            orderHeader.TotalPrice = orderViewModel.TotalPrice;
            foreach (var item in orderViewModel.items)
            {
                orderHeader.OrderDetails.Add(
                    new OrderDetail()
                    {
                        Item = item.Id,
                        UOM = 1,
                        Quantity = 1,
                        Discount = (int)item.Discount
                       
                    }
                    ); 
            }

            await context.AddAsync(orderHeader);
            context.SaveChanges();

        }

        //public List<OrderResponseViewModel> GetOrders()
        //{
        //   List <OrderResponseViewModel> orderResponseViewModel = new List<OrderResponseViewModel>();
        //    context.OrderHeaders.Include(a=>a.UserCustomer).Include(a=>a.OrderDetails).Select(
        //        x=>
        //        {
        //            orderResponseViewModel.customerName = x.UserCustomer.UserName;
        
        //        }).ToList();
        //    return orderResponseViewModel;
        //}

        //public List<OrderResponseViewModel> GetOrders(int id)
        //{
        //   List <OrderResponseViewModel> orderResponseViewModel = new List<OrderResponseViewModel>();


        //   var item = context.Items.FirstOrDefault(x => x.Id == ).Item;

        //    OrderResponseViewModel model = new OrderResponseViewModel()
        //    {

        //    };

        //    //return context.OrderDetails.Select(a => new OrderResponseViewModel {
        //    //   a.ItemObj.Item,
        //    //    a.TotalPrice,
        //    //    a.ItemObj.unitOfMeasure.UOM 
        //    //}).ToList();


        //}


        //List<OrderDetail> IOrderRepository.GetOrders()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
