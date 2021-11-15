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
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private IMediator mediator;

        public ItemController(ILogger<ItemController> logger,IMediator _mediator)
        {
            _logger = logger;
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ItemResponseDto>> CreateItem([FromBody]ItemRequestDto itemRequestDto)
        {
           var result= await mediator.Send(new CreateItemCommand()
            {
                RequestDto=itemRequestDto
            });
            return result;
           
        }

        [HttpPut]
        public async Task<ActionResult<ItemResponseDto>> UpdateItem([FromBody] ItemRequestDto itemRequestDto)
        {
            var result = await mediator.Send(new UpdateItemCommand()
            {
                RequestDto = itemRequestDto
            });
            return result;

        }
    }
}
