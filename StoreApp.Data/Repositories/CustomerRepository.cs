using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Repositories.Base;
using StoreApp.Domain.BusinessEntities.Customers;
using StoreApp.Domain.BusinessEntities.Orders;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.Repositories
{
    public class CustomerRepository: EntityRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
