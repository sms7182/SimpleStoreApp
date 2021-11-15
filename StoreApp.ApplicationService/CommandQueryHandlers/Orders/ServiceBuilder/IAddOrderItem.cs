using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder
{
    public interface IAddOrderItem
    {
        ICalculatePrice AddOrderItem(Guid itemId, decimal quantity);
    }
}
