using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.OMS.OrderingService.Domain.Entities.Enums
{
    public enum OrderStatus
    {
        Pending = 1, 
        Preparing = 2, 
        ReadyForPickup = 3,
        ReadyForDelivery = 4, 
        OutForDelivery = 5,
        Delivered = 6
    }
}
