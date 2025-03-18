using MediatR;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.OMS.OrderingService.Application.Commands
{
    public class UpdateOrderStatusCommand : IRequest<int>
    {
        public Guid OrderId { get; set; }
        public int OrderStatus { get; set; }
    }
}
