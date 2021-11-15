using StoreApp.ApplicationService.CommandQueryHandlers.Base;
using StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder;
using StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder;
using StoreApp.Contracts.CommandQueries.Item;
using StoreApp.Contracts.CommandQueries.Order;
using StoreApp.Contracts.Dtos.Items;
using StoreApp.Contracts.Dtos.Orders;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Orders
{
    public class CreateOrderCommandHandler:CommandQueryHandler<CreateOrderCommand,OrderRequestDto,OrderResponseDto>
    {
        IStoreUnitOfWork storeUnitOfWork;
        ICreateOrderService createOrderService;
        public CreateOrderCommandHandler(IStoreUnitOfWork _storeUnitOfWork,ICreateOrderService _createOrderService)
        {
            storeUnitOfWork = _storeUnitOfWork;
            createOrderService = _createOrderService;
        
        }

        public override async Task<OrderResponseDto> Handler(CreateOrderCommand req, CancellationToken ct)
        {
           var dto= req.RequestDto;
            try
            {
              var initOrder=  createOrderService.InitOrder(dto.CustomerId, dto.Discount, dto.DiscountType);
                ICalculatePrice calculatePrice=null;
                foreach(var orderitemDto in dto.OrderItems)
                {
                  calculatePrice=  initOrder.AddOrderItem(orderitemDto.ItemId, orderitemDto.Quantity);
                }
              var validate= await calculatePrice.CalculatePrice();
              var order=  validate.ValidateAndBuildOrder();
              await  storeUnitOfWork.OrderRepository.Add(order);
                await storeUnitOfWork.CommitAsync();
                return new OrderResponseDto()
                {
                    IsSuccess = true,
                 

                };
            }
            catch(Exception exp)
            {
                return new OrderResponseDto()
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
