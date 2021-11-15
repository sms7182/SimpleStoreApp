using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApp.Contracts.CommandQueries.Order;
using StoreApp.Contracts.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrderController:ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private IMediator mediator;

        public OrderController(ILogger<OrderController> logger, IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponseDto>> CreateItem([FromBody] OrderRequestDto itemRequestDto)
        {
            var result = await mediator.Send(new CreateOrderCommand()
            {
                RequestDto = itemRequestDto
            });
            return result;

        }

    }
}
