using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.BusinessEntities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder
{
    public class SendBreakableOrderService : ISendOrderService
    {
        private OrderItemDetail _orderItemDetail;

        public bool Satisfy(OrderItemDetail orderItemDetail)
        {
            _orderItemDetail = orderItemDetail;
            return orderItemDetail.ItemType == ItemType.Breakable;
        }

        public void Send()
        {
            ///todo send for normal
        }


    }
}
