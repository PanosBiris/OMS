using PB.OMS.OrderingService.Domain.Entities.Enums;

namespace PB.OMS.OrderingService.Api.Models
{
    public class OrderRequest
    {
        public string? Code { get; set; }
        public Guid CustomerId { get; set; }
        //public DateTime OrderTime { get; set; }
        public OrderType Type { get; set; }
        public OrderStatus Status { get; set; }
        public string? Notes { get; set; }
        public List<OrderItemRequest> Items { get; set; } = new List<OrderItemRequest>();
    }
}
