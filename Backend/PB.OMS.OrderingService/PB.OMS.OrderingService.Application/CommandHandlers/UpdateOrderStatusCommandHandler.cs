using MediatR;
using PB.OMS.OrderingService.Application.Commands;
using PB.OMS.OrderingService.Application.Repository;
using PB.OMS.OrderingService.Domain.Entities.Enums;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.OMS.OrderingService.Application.CommandHandlers
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<int> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.Get(request.OrderId, cancellationToken);
            
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            else 
            {
                //TODO: validate status based on type
                order.Status = (OrderStatus)request.OrderStatus;
                return await _orderRepository.UpdateOrderStatus(order);
            }
        }

    }
}
