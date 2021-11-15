﻿using StoreApp.Domain.BusinessEntities.Items;
using StoreApp.Domain.IDataAccess.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain.IDataAccess
{
    public interface IItemRepository:IGenericRepository<Item>
    {
    }
}
