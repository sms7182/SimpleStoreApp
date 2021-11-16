using StoreApp.ApplicationService.CommandQueryHandlers.Base;
using StoreApp.Contracts.CommandQueries.Order;
using StoreApp.Contracts.Dtos.Orders;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Orders
{
    public class GetOrderQueryHandler: CommandQueryHandler<GetOrderQuery, GetOrderRequestDto, GetOrderResponseDto>
    {
        IStoreUnitOfWork storeUnitOfWork;
        public GetOrderQueryHandler(IStoreUnitOfWork _storeUnitOfWork)
        {
            storeUnitOfWork = _storeUnitOfWork;
        }

        public override async Task<GetOrderResponseDto> Handler(GetOrderQuery query,CancellationToken ct)
        {
            var dto = query.RequestDto;
           var orderQuery=await storeUnitOfWork.OrderRepository.Find(d => d.CustomerId == dto.CustomerId);

           var data= orderQuery.Select(dt =>new {dt.Id, dt.CreationDate,dt.Discount,dt.DiscountType,dt.Price,dt.TotalPrice}).ToList();
            return new GetOrderResponseDto()
            {
                Data = data,
                IsSuccess = true
            };
        }
    }
}
