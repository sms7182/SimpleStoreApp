using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.IDataAccess.Base
{
    public interface IBaseWriteUnitOfWork
    {
        DbContext DbContext();
        Task CommitAsync();


        Task Rollback();
       
    }
}
