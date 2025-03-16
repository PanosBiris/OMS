using Microsoft.AspNetCore.Mvc;
using MediatR;
using PB.OMS.OrderingService.Api.Models;
using PB.OMS.OrderingService.Application.Commands;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;
using Microsoft.AspNetCore.Components.Forms;
using PB.OMS.OrderingService.Application.Queries;

namespace PB.OMS.OrderingService.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Create(OrderRequest request,
            CancellationToken cancellationToken)
        {
            var orderCommand = new CreateOrderCommand();
            orderCommand.Code = request.Code;
            orderCommand.CustomerId = request.CustomerId;
            orderCommand.OrderTime = DateTime.Now;
            orderCommand.Type = request.Type;
            orderCommand.Status = request.Status;
            orderCommand.Notes = request.Notes;
            orderCommand.Items = new List<OrderItem>();
            foreach (OrderItemRequest item in request.Items)
            {
                orderCommand.Items.Add(new OrderItem() 
                { 
                    MenuItemId = item.MenuItemId, 
                    Quantity = item.Quantity, 
                    SpecialInstructions = item.SpecialInstructions 
                });
            }

            var response = await _mediator.Send(orderCommand, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            var orders = await _mediator.Send(new GetOrdersByCustomerIdQuery() { CustomerId = customerId });

            return orders;
        }
    }
}
