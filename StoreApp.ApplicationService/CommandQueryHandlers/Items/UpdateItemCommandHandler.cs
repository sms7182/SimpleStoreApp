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
    public class UpdateItemCommandHandler:CommandQueryHandler<UpdateItemCommand,ItemRequestDto,ItemResponseDto>
    {
        IStoreUnitOfWork storeUnitOfWork;
        IUpdateItemService updateItemService;
        public UpdateItemCommandHandler(IStoreUnitOfWork _storeUnitOfWork,IUpdateItemService _updateItemService)
        {
            storeUnitOfWork = _storeUnitOfWork;
            updateItemService = _updateItemService;
        }

        public override async Task<ItemResponseDto> Handler(UpdateItemCommand req, CancellationToken ct)
        {
           var dto= req.RequestDto;
            try
            {
              var itemRepository=  storeUnitOfWork.ItemRepository;
             var item= await  itemRepository.GetById(req.Id);
                var updateItem = updateItemService
                     .UpdateInit(item,dto.ItemType)
                     .SetTitle(dto.Title)
                     .SetPrice(dto.Price)
                     .SetProfit(dto.Profit)
                     .ValidateAndBuild();
               await   storeUnitOfWork.ItemRepository.Update(item);
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
