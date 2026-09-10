using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class ProductRepository : GenericRepository<Product, AppDbContext>,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        
    }
}
