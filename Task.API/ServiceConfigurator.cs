using Task.Business.Abstract;
using Task.Business.Concrete;
using Task.DataAccess.Abstract;
using Task.DataAccess.Concrete.EntityFramework;

namespace Task.API
{
    public class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
   
            services.AddSingleton<IProductDal, EfProductDal>();
            services.AddSingleton<IProductService, ProductManager>();

        }
    }
}
