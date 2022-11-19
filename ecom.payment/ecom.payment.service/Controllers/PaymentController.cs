using Dapr;
using Dapr.Client;
using ecom.payment.domain.Order;
using Microsoft.AspNetCore.Mvc;

namespace ecom.payment.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> logger;
        private readonly DaprClient _daprClient;
        public PaymentController(ILogger<PaymentController> logger, DaprClient daprClient)
        {
            this._daprClient = daprClient;
            this.logger = logger;
        }
        [HttpPost("", Name = "SubmitOrder")]
        [Topic("orderpubsub", "orders")]
        public async Task<IActionResult> Submit(Order order)
        {
            logger.LogInformation($"Payment service received for new order: {order.OrderId} message from orders topic");
            logger.LogInformation($"Order Details --> Product: {order.ProductId}, Product Quantity: {order.ProductCount}, Price: {order.OrderPrice}");

            await _daprClient.PublishEventAsync("orderpubsub", "payments", order);
            logger.LogInformation($"payment done and published to orderpubsub component and payments topic for: {order.OrderId}");

            return Ok();
        }
    }
}
