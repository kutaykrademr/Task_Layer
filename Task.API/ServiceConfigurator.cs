using Task.Business.Abstract;
using Task.Business.Concrete;
using Task.DataAccess.Abstract;
using Task.DataAccess.Concrete.EntityFramework;
using Task.DataAccess.Concrete.Postgre;

namespace Task.API
{
    public class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services)
        {

            //services.AddScoped<ILogDataDal, PostgreLogDataDal>(); 
            //services.AddScoped<IProductDal, PostgreProductDal>();

            services.AddScoped<ILogDataDal, EfLogDataDal>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ILogDataService, LogDataManager>();

        }
    }
}
