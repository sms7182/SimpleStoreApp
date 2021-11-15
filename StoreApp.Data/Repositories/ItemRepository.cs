using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Repositories.Base;
using StoreApp.Domain.BusinessEntities.Items;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.Repositories
{
    public class ItemRepository: EntityRepository<Item>, IItemRepository
    {
        public ItemRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
