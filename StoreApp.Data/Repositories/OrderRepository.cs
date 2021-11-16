using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Repositories.Base;
using StoreApp.Domain.BusinessEntities.Orders;
using StoreApp.Domain.IDataAccess;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using StoreApp.Domain.BusinessEntities.Items;
using StoreApp.Domain.BusinessEntities.Customers;
using StoreApp.Contracts.Dtos.Orders;
using System.Threading.Tasks;

namespace StoreApp.Data.Repositories
{
    public class OrderRepository: EntityRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
          
        }

        public async Task<List<OrderItemDetail>> GetOrderItemPerItemType(Guid orderId)
        {
            var data = (from or in _dbContext.Set<Order>()
                        join ori in _dbContext.Set<OrderItem>() on or.Id equals ori.OrderId
                        join it in _dbContext.Set<Item>() on ori.ItemId equals it.Id
                        join cs in _dbContext.Set<Customer>() on or.CustomerId equals cs.Id
                        where or.Id == orderId
                        select new OrderItemDetail { Quantity= ori.Quantity,Title= it.Title,ItemType= it.ItemType });
            return await data.ToListAsync(); 

           

        }
    }
}
