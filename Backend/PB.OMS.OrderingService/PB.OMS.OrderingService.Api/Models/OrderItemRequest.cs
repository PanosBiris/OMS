namespace PB.OMS.OrderingService.Api.Models
{
    public class OrderItemRequest
    {
        public Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string? SpecialInstructions { get; set; }
    }
}
