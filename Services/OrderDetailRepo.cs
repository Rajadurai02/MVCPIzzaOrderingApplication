using PizzaOrderingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPIzzaOrderingApplication.Services
{
    public class OrderDetailRepo : IRepo<OrderDetail>
    {
        private readonly pizzaContext _context;

        public OrderDetailRepo(pizzaContext context)
        {
            _context = context; 
        }
        public ICollection<OrderDetail> GetOrderDetails()
        {
            IList<OrderDetail> orderDetails = _context.OrderDetails.ToList();
            if (orderDetails.Count > 0)
                return orderDetails;
            else
                return null;
        }

        public OrderDetail GetOrderItemDetails(int orderId)
        {
            OrderDetail order = _context.OrderDetails.FirstOrDefault(e => e.OrderId == orderId);
            return order;
        }
    }
}
