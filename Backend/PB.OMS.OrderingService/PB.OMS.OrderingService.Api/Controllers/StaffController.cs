using MediatR;
using Microsoft.AspNetCore.Mvc;
using PB.OMS.OrderingService.Api.Models;
using PB.OMS.OrderingService.Application.Commands;
using PB.OMS.OrderingService.Domain.Entities.OrderAggregate;

namespace PB.OMS.OrderingService.Api.Controllers
{
    public class StaffController : BaseController
    {
        private readonly IMediator _mediator;

        public StaffController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> UpdateStatus(UpdateOrderStatusCommand request,
           CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
