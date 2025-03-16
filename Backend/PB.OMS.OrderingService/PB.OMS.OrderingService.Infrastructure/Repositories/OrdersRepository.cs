using Microsoft.EntityFrameworkCore;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PB.OMS.OrderingService.Application.Repository;

namespace PB.OMS.OrderingService.Infrastructure.Repositories
{
    public class OrdersRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly OrdersContext _context;
        public OrdersRepository(OrdersContext context) : base(context)
        {
            _context = context;
        }        

        async Task<ICollection<Order>> IOrderRepository.GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        Task<Order> IOrderRepository.GetOrderById(Guid orderId)
        {
            throw new NotImplementedException();
        }

        async Task<List<Order>> IOrderRepository.GetOrdersByCustomerId(Guid customerId)
        {
            return await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<Order> AddOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return newOrder;
        }
    }
}