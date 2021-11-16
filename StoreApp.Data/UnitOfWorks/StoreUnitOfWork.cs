using StoreApp.Data.Configuration;
using StoreApp.Data.Repositories;
using StoreApp.Data.UnitOfWorks.Base;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.UnitOfWorks
{
    public class StoreUnitOfWork:BaseWriteUnitOfWork,IStoreUnitOfWork
    {
        public StoreUnitOfWork(StoreDBContext applicationDBContext, IServiceProvider serviceProvider) : base(applicationDBContext, serviceProvider)
        {

        }

        IItemRepository itemRepository;
        public IItemRepository ItemRepository { get { return itemRepository ??= new ItemRepository(DbContext()); } }


        IOrderRepository orderRepository;
        public IOrderRepository OrderRepository { get { return orderRepository ??= new OrderRepository(DbContext()); } }

        ICustomerRepository customerRepository;
        public ICustomerRepository CustomerRepository { get { return customerRepository ??= new CustomerRepository(DbContext()); } }
    }
}
