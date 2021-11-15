using StoreApp.Domain.BusinessEntities.Orders;
using StoreApp.Domain.IDataAccess.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain.IDataAccess
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
    }
}
