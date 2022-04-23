using DescontroladaAPI.Business;
using DescontroladaAPI.Interfaces;
using DescontroladaAPI.Repository;

namespace DescontroladaAPI
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IProductBusiness, ProductBusiness>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
