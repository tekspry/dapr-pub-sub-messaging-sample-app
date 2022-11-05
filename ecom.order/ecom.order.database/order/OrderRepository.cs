using ecom.order.domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecom.order.database.order
{
    public class OrderRepository : IOrderRepository
    {
        public Task<string> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
