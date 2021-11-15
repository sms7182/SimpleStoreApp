using StoreApp.Domain.BusinessEntities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder
{
    public interface IValidateAndBuildOrder
    {
        Order ValidateAndBuildOrder();
    }
}
