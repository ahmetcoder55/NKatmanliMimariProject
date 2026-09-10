using DataAccess.Abstract;
using DataAccess.Abstract.UnitOfWorks;
using DataAccess.Concrete.Contexts;
using DataAccess.Concrete.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Extensions
{
    public static class DataAccessExtension
    {
        public static void ConfigureDatabase(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
        }
        public static void ConfigureDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }

}
