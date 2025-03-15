using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.OMS.OrderingService.Application.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<ICollection<Order>> GetAll();

        Task<Order> GetOrderById(int personId);

        Task<Order> AddOrder(Order toCreate);

    }
}
