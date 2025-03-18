using MediatR;
using PB.OMS.OrderingService.Application.Commands;
using PB.OMS.OrderingService.Application.Repository;
using PB.OMS.OrderingService.Domain.Entities.Enums;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;

namespace PB.OMS.OrderingService.Application.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Code = request.Code,
                CustomerId = request.CustomerId,
                OrderTime = request.OrderTime,
                Type = request.Type,
                Status = OrderStatus.Pending, //TODO: Status not required when creating as it is always pending
                Notes = request.Notes,
                OrderItems = request.Items
            };

            return await _orderRepository.AddOrder(order);
        }
    };
}