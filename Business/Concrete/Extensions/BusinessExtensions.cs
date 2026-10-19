using Business.Abstract.Services;
using Business.Concrete.Managers;
using Business.Concrete.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Concrete.Extensions
{
    public static class BusinessExtensions
    {
        public static void ConfigureBusiness(this IServiceCollection services)
        {
            //AutoMapper Config

            services.AddAutoMapper(options =>
            {
                options.AddMaps(typeof(MappingProfile));
            });

            services.AddScoped<IProductService,ProductManager>();
        }
    }
}