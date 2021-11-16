using StoreApp.Domain.BusinessEntities.Orders;
using StoreApp.Domain.IDataAccess.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.IDataAccess
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        Task<List<OrderItemDetail>> GetOrderItemPerItemType(Guid orderId);
    }
}
