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

        [HttpPost("createOrder")]
        public async Task<ActionResult<OrderResponseDto>> CreateOrder([FromBody] OrderRequestDto orderRequestDto)
        {
            var result = await mediator.Send(new CreateOrderCommand()
            {
                RequestDto = orderRequestDto
            });
            return result;

        }

        [HttpPost("getorderwithcustomer")]
        public async Task<ActionResult<GetOrderResponseDto>> GetOrderWithCustomer([FromBody]GetOrderRequestDto orderRequestDto)
        {
            var result = await mediator.Send(new GetOrderQuery()
            {
                RequestDto = orderRequestDto
            });
            return result;
        }

        [HttpPost("sendOrder")]
        public async Task<ActionResult<SendOrderResDto>> SendOrder([FromBody] SendOrderReqDto orderRequestDto)
        {
            var result = await mediator.Send(new SendOrderCommand()
            {
                RequestDto = orderRequestDto
            });
            return result;
        }

    }
}
