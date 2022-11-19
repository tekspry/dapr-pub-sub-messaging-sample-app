using Dapr;
using ecom.payment.domain.Order;
using Microsoft.AspNetCore.Mvc;

namespace ecom.payment.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> logger;
        public PaymentController(ILogger<PaymentController> logger)
        {
            this.logger = logger;
        }
        [HttpPost("", Name = "SubmitOrder")]
        [Topic("daprpubsub", "orders")]
        public async Task<IActionResult> Submit(Order order)
        {
            logger.LogInformation($"Payment service received for new order: {order.OrderId} message");
            logger.LogInformation($"Order Details --> Product: {order.ProductId}, Product Quantity: {order.ProductCount}, Price: {order.OrderPrice}");

            return Ok();
        }
    }
}
