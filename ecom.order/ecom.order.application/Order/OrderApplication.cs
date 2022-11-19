using Dapr.Client;
using ecom.order.database.order;
using ecom.order.domain.Order;
using ecom.order.infrastructure.Product;
using Microsoft.Extensions.Logging;

namespace ecom.order.application.Order
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IProductService _productService;
        private readonly IOrderRepository _orderRepository;
        private readonly DaprClient _daprClient;
        private readonly ILogger<OrderApplication> logger;

        public OrderApplication(IProductService productService, IOrderRepository orderRepository, DaprClient daprClient, ILogger<OrderApplication> logger)
        {
            _productService = productService;
            _orderRepository = orderRepository;
            this._daprClient = daprClient;
            this.logger = logger;
        }
        public async Task<ecom.order.domain.Order.Order> AddAsync(ecom.order.domain.Order.Order order)
        {   

            var productPrice = await _productService.UpdateProductQuantity(order.ProductId, order.ProductCount);
            logger.LogInformation($"product quantity updated for product: {order.ProductId}");
            order.OrderId = Guid.NewGuid().ToString();            
            order.OrderState = OrderState.OrderPlaced;

            await _orderRepository.CreateOrder(order);
            logger.LogInformation($"order created for: {order.OrderId}");

            await _daprClient.PublishEventAsync("orderpubsub", "orders", order);
            logger.LogInformation($"order published to orderpubsub component for: {order.OrderId}");

            return order;
        }
    }
}
