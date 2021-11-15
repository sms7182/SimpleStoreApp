using StoreApp.Domain.BusinessEntities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder
{
    public interface ICreateOrderService
    {
        IAddOrderItem InitOrder(Guid? customerId,decimal? discount=null, DiscountType? discountType = null);
       
    }
}
