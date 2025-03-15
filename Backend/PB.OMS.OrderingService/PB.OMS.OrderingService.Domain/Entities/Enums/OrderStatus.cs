using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.OMS.OrderingService.Domain.Entities.Enums
{
    public enum OrderStatus
    {
        Pending, 
        Preparing, 
        ReadyForPickup,
        ReadyForDelivery, 
        OutForDelivery,
        Delivered
    }
}
