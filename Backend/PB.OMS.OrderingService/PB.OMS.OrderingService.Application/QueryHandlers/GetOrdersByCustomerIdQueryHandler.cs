using MediatR;
using PB.OMS.OrderingService.Application.Commands;
using PB.OMS.OrderingService.Application.Queries;
using PB.OMS.OrderingService.Application.Repository;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.OMS.OrderingService.Application.QueryHandlers
{
    public class GetOrdersByCustomerIdQueryHandler : IRequestHandler<GetOrdersByCustomerIdQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByCustomerIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrdersByCustomerId(request.CustomerId);
        }
    }
}
