using Microsoft.EntityFrameworkCore;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;
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
        
        async Task<List<Order>> IOrderRepository.GetOrdersByCustomerId(Guid customerId)
        {
            return await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        async Task<Order> IOrderRepository.GetOrderById(Guid orderId)
        {
            return await _context.Orders.Where(o => o.Id == orderId).Include(o => o.OrderItems).FirstOrDefaultAsync();
        }

        public async Task<Order> AddOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return newOrder;
        }

        public async Task<int> UpdateOrderStatus(Order order)
        {
            return await
            _context.Orders.Where(o => o.Id == order.Id).ExecuteUpdateAsync
                (x => x.SetProperty(p => p.Status, order.Status));
        }
    }
}