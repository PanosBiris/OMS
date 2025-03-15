using Microsoft.EntityFrameworkCore;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;

namespace PB.OMS.OrderingService.Infrastructure.Repositories
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options) { }
    }
}
