using StoreApp.ApplicationService.CommandQueryHandlers.Base;
using StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder;
using StoreApp.Contracts.CommandQueries.Item;
using StoreApp.Contracts.Dtos.Items;
using StoreApp.Domain.BusinessEntities.Customers;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Customers
{
    public class CreateCustomerCommandHandler:CommandQueryHandler<CreateCustomerCommand,CustomerRequestDto,CustomerResponseDto>
    {
        IStoreUnitOfWork storeUnitOfWork;
       
        public CreateCustomerCommandHandler(IStoreUnitOfWork _storeUnitOfWork)
        {
            storeUnitOfWork = _storeUnitOfWork;
        
        }

        public override async Task<CustomerResponseDto> Handler(CreateCustomerCommand req, CancellationToken ct)
        {
           var dto= req.RequestDto;
            try
            {
              var customer=  Customer.CreateInstance();
                customer.SetTitle(dto.Title);
                customer.SetAddress(dto.Address);
               await   storeUnitOfWork.CustomerRepository.Add(customer);
                await storeUnitOfWork.CommitAsync();
                return new CustomerResponseDto()
                {
                    IsSuccess = true,
                    Id = customer.Id

                };
            }
            catch(Exception exp)
            {
                return new CustomerResponseDto()
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
