using MediatR;
using PB.OMS.OrderingService.Domain.Entities.Enums;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;

namespace PB.OMS.OrderingService.Application.Commands;

public class CreateOrderCommand : IRequest<Order>
{
    public string? Code { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderTime { get; set; }
    public OrderType Type { get; set; }
    public OrderStatus Status { get; set; }
    public string? Notes { get; set; }
    public List<OrderItem>? Items { get; set; }
};