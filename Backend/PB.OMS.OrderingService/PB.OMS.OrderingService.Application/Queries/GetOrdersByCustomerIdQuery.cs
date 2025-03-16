using MediatR;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.OMS.OrderingService.Application.Queries
{
    public class GetOrdersByCustomerIdQuery : IRequest<List<Order>>
    {
        public Guid CustomerId { get; set; }
    }
}
