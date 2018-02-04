using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Part> PartRepositoy { get; }
        IRepository<StoreKeeper> StoreKeeperRepositoy { get; }
        
        Task SaveChangesAsync();
    }
}
