using StoreApp.Contracts.CommandQueries.Base;
using StoreApp.Contracts.Dtos;
using StoreApp.Contracts.Dtos.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.CommandQueries.Item
{
    public class CreateItemCommand:CommandQuery<ItemRequestDto,ItemResponseDto>
    {
    }
}
