using Microsoft.EntityFrameworkCore;
using StoreApp.Domain.IDataAccess;
using StoreApp.Domain.IDataAccess.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.UnitOfWorks.Base
{
    public class BaseWriteUnitOfWork : IBaseWriteUnitOfWork, IDisposable
    {
        private bool disposed = false;
        public BaseWriteUnitOfWork(DbContext dbContext, IServiceProvider serviceProvider) 
        {
        
        }

        public DbContext context;
      

        public DbContext DbContext()
        {
            return context;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task CommitAsync()
        {

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    await context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            


        }

        public async Task Rollback()
        {
            await context.Database.RollbackTransactionAsync();
        }

   
    }
}
