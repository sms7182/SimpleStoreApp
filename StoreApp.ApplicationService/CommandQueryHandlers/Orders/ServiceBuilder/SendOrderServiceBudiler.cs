using StoreApp.Domain.BusinessEntities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder
{
    public class SendOrderServiceBudiler : ISendOrderServiceBuilder
    {

        List<ISendOrderService> _sendOrderServices;
        public SendOrderServiceBudiler(IEnumerable<ISendOrderService> sendOrderServices)
        {
            _sendOrderServices = sendOrderServices.ToList();

        }

        public void Send(List<OrderItemDetail> orderItemDetails)
        {

            foreach (var detail in orderItemDetails)
            {
                var sendOrderService = _sendOrderServices.FirstOrDefault(d => d.Satisfy(detail));
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
