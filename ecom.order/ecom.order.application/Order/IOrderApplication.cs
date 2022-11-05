using ecom.order.domain.Order;

namespace ecom.order.application.Order
{
    public interface IOrderApplication
    {
        Task<ecom.order.domain.Order.Order> AddAsync(ecom.order.domain.Order.Order order);
    }
}
