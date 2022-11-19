namespace ecom.payment.domain.Order
{
    public class Order
    {
        public string? OrderId { get; set; }
        public string? ProductId { get; set; }
        public int ProductCount { get; set; }
        public int OrderPrice { get; set; }
        public OrderState OrderState { get; set; }
    }
}
