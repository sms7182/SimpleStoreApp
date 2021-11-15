using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Repositories.Base;
using StoreApp.Domain.BusinessEntities.Orders;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.Repositories
{
    public class OrderRepository: EntityRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
