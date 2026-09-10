using DataAccess.Abstract;
using DataAccess.Abstract.UnitOfWorks;
using DataAccess.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private readonly Lazy<IProductRepository> _productRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context));
        }

        public IProductRepository Products => _productRepository.Value;

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
