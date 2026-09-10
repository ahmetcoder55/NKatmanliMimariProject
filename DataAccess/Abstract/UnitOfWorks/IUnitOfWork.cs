using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        public IProductRepository Products { get; }

        Task<int> SaveChangesAsync();
    }
}
