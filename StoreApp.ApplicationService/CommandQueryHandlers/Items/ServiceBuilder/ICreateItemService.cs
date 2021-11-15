using StoreApp.Domain.BusinessEntities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder
{
    public interface ICreateItemService
    {
        ISetTitle CreateInit(ItemType itemType);
    }
}
