using Application.Person.CommandHandlers;
using Moq;
using PB.OMS.OrderingService.Application.Commands;
using PB.OMS.OrderingService.Application.Repository;
using PB.OMS.OrderingService.Domain.Entities.Enums;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;
using PB.OMS.OrderingService.Infrastructure.Repositories;

namespace PB.OMS.OrderingService.Application.Test
{
    public class CreateOrderCommandHandlerTest
    {
        private readonly Mock<IOrderRepository> _orderRepository;

        public CreateOrderCommandHandlerTest()
        {
            _orderRepository = new Mock<IOrderRepository>();
        }

        [Fact]
        public async Task CreateOrderCommandHandler_ShouldCreateNewOrderAsync()
        {
            var handler = new CreateOrderCommandHandler(_orderRepository.Object);

            // Act
            var command = new CreateOrderCommand()
            {
                Code = "X15000",
                CustomerId = Guid.NewGuid(),
                OrderTime = DateTime.Now,
                Type = OrderType.Pickup,
                Status = OrderStatus.Pending,
                Notes = "test",
                Items = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        MenuItemId = Guid.NewGuid(),
                        Quantity = 1,
                        SpecialInstructions = "test"
                    }
                }
            };            
            var result = await handler.Handle(command, CancellationToken.None);

            _orderRepository.Verify(r => r.Create(result), Times.Once);          
        }
    }
}
