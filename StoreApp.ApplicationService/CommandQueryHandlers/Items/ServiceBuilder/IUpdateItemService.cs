using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.BusinessEntities.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder
{
    public interface IUpdateItemService
    {
        ISetTitle UpdateInit(Item item,ItemType itemType);
    }
}
