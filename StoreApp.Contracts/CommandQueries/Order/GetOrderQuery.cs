using StoreApp.Contracts.CommandQueries.Base;
using StoreApp.Contracts.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.CommandQueries.Order
{
    public class GetOrderQuery: CommandQuery<GetOrderRequestDto, GetOrderResponseDto>
    {
    }
}
