using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApp.Contracts.CommandQueries.Item;
using StoreApp.Contracts.Dtos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private IMediator mediator;

        public CustomerController(ILogger<CustomerController> logger,IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponseDto>> CreateItem([FromBody]CustomerRequestDto customerRequestDto)
        {
           var result= await mediator.Send(new CreateCustomerCommand()
            {
                RequestDto=customerRequestDto
            });
            return result;
           
        }

    
    }
}
