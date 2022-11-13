using Dapr.Client;
using ecom.order.domain.Order;
using Microsoft.Extensions.Logging;

namespace ecom.order.database.order
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> orders = new List<Order>();
        private readonly DaprClient daprClient;
        private readonly ILogger<OrderRepository> logger;
        private const string cacheStoreName = "ordercache";

        public OrderRepository(DaprClient daprClient, ILogger<OrderRepository> logger)
        {
            this.daprClient = daprClient;
            this.logger = logger;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            order.OrderId = Guid.NewGuid().ToString();
            var key = $"orderlist";
            var orders = await daprClient.GetStateAsync<List<Order>>(cacheStoreName, "orderlist");

            if (orders == null)
                orders = new List<Order>();
                       
            orders.Add(order);
            
            await this.SaveOrderListToCacheStore(orders);

            return await Task.FromResult(order);
        }
        private async Task SaveOrderListToCacheStore(List<Order> orders)
        {
            var key = $"productlist";
            await daprClient.SaveStateAsync(cacheStoreName, key, orders);
            logger.LogInformation($"Created new order in cache store {key}");
        }
    }
}
