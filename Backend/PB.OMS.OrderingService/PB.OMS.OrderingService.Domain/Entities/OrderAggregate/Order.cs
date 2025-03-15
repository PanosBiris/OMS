using PB.OMS.OrderingService.Domain.Common;
using PB.OMS.OrderingService.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.OMS.OrderingService.Domain.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        
        public string? Code {  get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderType Type { get; set; }
        public OrderStatus Status { get; set; }
        public string? Notes { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
