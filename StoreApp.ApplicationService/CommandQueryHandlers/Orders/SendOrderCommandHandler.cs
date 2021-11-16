using Microsoft.EntityFrameworkCore;
using StoreApp.ApplicationService.CommandQueryHandlers.Base;
using StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder;
using StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder;
using StoreApp.Contracts.CommandQueries.Item;
using StoreApp.Contracts.CommandQueries.Order;
using StoreApp.Contracts.Dtos.Items;
using StoreApp.Contracts.Dtos.Orders;
using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.BusinessEntities.Orders;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Orders
{
    public class SendOrderCommandHandler:CommandQueryHandler<SendOrderCommand,SendOrderReqDto,SendOrderResDto>
    {
        IStoreUnitOfWork storeUnitOfWork;
        ISendOrderServiceBuilder _sendOrderServiceBuild;
        public SendOrderCommandHandler(IStoreUnitOfWork _storeUnitOfWork,ISendOrderServiceBuilder sendOrderServiceBuilder)
        {
            storeUnitOfWork = _storeUnitOfWork;
            _sendOrderServiceBuild = sendOrderServiceBuilder;
        
        }

        public override async Task<SendOrderResDto> Handler(SendOrderCommand req, CancellationToken ct)
        {
           var dto= req.RequestDto;
            try
            {
             var orderPerType=   await storeUnitOfWork.OrderRepository.GetOrderItemPerItemType(dto.OrderId);

                _sendOrderServiceBuild.Send(orderPerType);
              var order= await storeUnitOfWork.OrderRepository.GetById(dto.OrderId);
                order.SetStatus(OrderStatus.Send);
               await storeUnitOfWork.OrderRepository.Update(order);
              await  storeUnitOfWork.CommitAsync();
                return new SendOrderResDto()
                {
                    IsSuccess = true
                };
            }
            catch(Exception exp)
            {
                return new SendOrderResDto()
                {
                    IsSuccess = false,
                    Data = new List<string>()
                 {
                     exp.Message
                 }
                };
            }
           
                
        }
    }
}
