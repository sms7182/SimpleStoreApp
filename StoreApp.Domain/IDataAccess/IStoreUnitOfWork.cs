using StoreApp.Domain.IDataAccess.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain.IDataAccess
{
    public interface IStoreUnitOfWork:IBaseWriteUnitOfWork
    {
        IItemRepository ItemRepository { get; }
        IOrderRepository OrderRepository { get; }

        ICustomerRepository CustomerRepository { get; }
    }
}
