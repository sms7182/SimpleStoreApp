using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.BusinessEntities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder
{

   
    public interface ISendOrderService
    {
        void Send();
        bool Satisfy(OrderItemDetail orderItemDetail);
    }
   

   

     
}
