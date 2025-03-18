using Application.Person.CommandHandlers;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PB.OMS.OrderingService.Application.Commands;
using PB.OMS.OrderingService.Application.Repository;
using PB.OMS.OrderingService.Domain.Entities.Enums;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;
using PB.OMS.OrderingService.Infrastructure.Repositories;

namespace PB.OMS.OrderingService.Test
{
    public class Infrastrucrure_Repository_CheckOrderIsCreated
    {
        private readonly IOrderRepository _orderRepository;
        private readonly string connectionString = "Server=localhost;Database=OrdersDB;Trusted_Connection=True;TrustServerCertificate=true;";

        public Infrastrucrure_Repository_CheckOrderIsCreated()
        { 
            
            var options = new DbContextOptionsBuilder<OrdersContext>()
                    .UseSqlServer(connectionString)
                    .Options;
            var context = new OrdersContext(options);
            var orderReporsitry = new OrdersRepository(context);
            _orderRepository = orderReporsitry;                
        }

        [Fact]
        public async Task Test1Async()
        {            
            var handler = new CreateOrderCommandHandler(_orderRepository);
            var newOrder = new CreateOrderCommand()
            {
                CustomerId = new Guid(),
                Code = "UT10001",
                OrderTime = DateTime.Now,
                Type = OrderType.Delivey,
                Status = OrderStatus.Pending,
                Notes = "Test Notes",
                Items = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        MenuItemId = new Guid(),
                        Quantity = 1,
                        SpecialInstructions = "Test Instructions",
                    }
                }
            };

            // Act
            var result = await handler.Handle(newOrder, CancellationToken.None);

            // Assert
            Assert.True(Guid.TryParse(result.Id.ToString(), out _));
        }
    }
}
