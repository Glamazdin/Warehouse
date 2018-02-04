using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.DAL
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbContext context;
        private IRepository<Part> _partRepositoy;
        private IRepository<StoreKeeper> _storeKeeperRepositoy;

        public EFUnitOfWork(DbContext ctx)
        {
            context = ctx;
        }

        public IRepository<Part> PartRepositoy
        {
            get
            {
                if(_partRepositoy==null)
                {
                    _partRepositoy = new GenericRepository<Part>(context);
                }
                return _partRepositoy;
            }
        }

        public IRepository<StoreKeeper> StoreKeeperRepositoy
        {
            get
            {
                if(_storeKeeperRepositoy==null)
                {
                    _storeKeeperRepositoy = new GenericRepository<StoreKeeper>(context);
                }
                return _storeKeeperRepositoy;
            }
        }

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();


        #region IDisposable
        // Реализация интерфейса IDisposable
        // смотри https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
        //
        private bool disposed = false;

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

        #endregion
    }
}
