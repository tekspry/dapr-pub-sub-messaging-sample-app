using ecom.order.domain.Order;
using ecom.order.infrastructure.Product;
using Microsoft.Extensions.Logging;

namespace ecom.order.application.Order
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IProductService _productService;

        private readonly ILogger<OrderApplication> logger;

        public OrderApplication(IProductService productService, ILogger<OrderApplication> logger)
        {
            _productService = productService;
            this.logger = logger;
        }
        public async Task<ecom.order.domain.Order.Order> AddAsync(ecom.order.domain.Order.Order order)
        {   

            var productPrice = await _productService.UpdateProductQuantity(order.ProductId, order.ProductCount);
            order.OrderId = Guid.NewGuid().ToString();
            //order.OrderPrice = order.ProductCount * productPrice;
            order.OrderState = OrderState.OrderPlaced;

            return order;
        }
    }
}
