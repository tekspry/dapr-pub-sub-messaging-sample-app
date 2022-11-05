using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecom.order.domain.Customers;

namespace ecom.order.domain.Order
{
    public record OrderDetails(DateTimeOffset orderDate, Customer customerDetails, IEnumerable<Order> orders);
    
}
