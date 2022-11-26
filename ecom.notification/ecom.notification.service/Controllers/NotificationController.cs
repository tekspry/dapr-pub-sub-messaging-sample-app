using Dapr;
using ecom.notification.domain.Order;
using Microsoft.AspNetCore.Mvc;

namespace ecom.notification.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> logger;
        public NotificationController(ILogger<NotificationController> logger)
        {
            this.logger = logger;
        }
        [HttpPost("", Name = "SubmitOrder")]
        [Topic("orderpubsub", "payments")]
        public async Task<IActionResult> Submit(Order order)
        {
            logger.LogInformation($"Notification service received for new order: {order.OrderId} message from payment service");
            logger.LogInformation($"Order Details --> Product: {order.ProductId}, Product Quantity: {order.ProductCount}, Price: {order.OrderPrice}");

            return Ok();
        }
    }
}
