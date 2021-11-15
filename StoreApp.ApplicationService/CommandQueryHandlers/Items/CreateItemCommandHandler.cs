using StoreApp.ApplicationService.CommandQueryHandlers.Base;
using StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder;
using StoreApp.Contracts.CommandQueries.Item;
using StoreApp.Contracts.Dtos.Items;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Items
{
    public class CreateItemCommandHandler:CommandQueryHandler<CreateItemCommand,ItemRequestDto,ItemResponseDto>
    {
        IStoreUnitOfWork storeUnitOfWork;
        ICreateItemService createItemService;
        public CreateItemCommandHandler(IStoreUnitOfWork _storeUnitOfWork,ICreateItemService _createItemService)
        {
            storeUnitOfWork = _storeUnitOfWork;
            createItemService = _createItemService;
        }

        public override async Task<ItemResponseDto> Handler(CreateItemCommand req, CancellationToken ct)
        {
           var dto= req.RequestDto;
            try
            {
                var item = createItemService
                     .CreateInit(dto.ItemType)
                     .SetTitle(dto.Title)
                     .SetPrice(dto.Price)
                     .SetProfit(dto.Profit)
                     .ValidateAndBuild();
               await   storeUnitOfWork.ItemRepository.Add(item);
                await storeUnitOfWork.CommitAsync();
                return new ItemResponseDto()
                {
                    IsSuccess = true,
                    Id = item.Id

                };
            }
            catch(Exception exp)
            {
                return new ItemResponseDto()
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
