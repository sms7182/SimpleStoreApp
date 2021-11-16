using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.BusinessEntities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ///todfo send for normal
        }


    }
    public class SendNormalOrderService : ISendOrderService
    {
        private OrderItemDetail _orderItemDetail;

        public bool Satisfy(OrderItemDetail orderItemDetail)
        {
            _orderItemDetail = orderItemDetail;
            return orderItemDetail.ItemType == ItemType.Normal;
        }

        public void Send()
        {
        ///todfo send for normal
        }

    }
    public interface ISendOrderService
    {
        void Send();
        bool Satisfy(OrderItemDetail orderItemDetail);
    }
    public interface ISendOrderServiceBuilder
    {
      void  Send(List<OrderItemDetail> orderItemDetails);
    }

    public class SendOrderServiceBudiler:ISendOrderServiceBuilder
    {

        List<ISendOrderService> _sendOrderServices;
        public SendOrderServiceBudiler(IEnumerable<ISendOrderService> sendOrderServices)
        {
            _sendOrderServices = sendOrderServices.ToList();

        }

        public void Send(List<OrderItemDetail> orderItemDetails)
        {
        
           foreach(var detail in orderItemDetails)
            {
              var sendOrderService=  _sendOrderServices.FirstOrDefault(d => d.Satisfy(detail));
                if (sendOrderService != null)
                {
                    sendOrderService.Send();
                }
                else
                {
                    //todo for handler other types
                }
            }
        }
    }

     
}
