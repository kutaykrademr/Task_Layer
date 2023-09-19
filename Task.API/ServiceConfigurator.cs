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

            //services.AddScoped<IProductDal, EfProductDal>(); //Mssql
            services.AddScoped<IProductDal, PostgreProductDal>(); //PostgreSql
            services.AddScoped<IProductService, ProductManager>();

        }
    }
}
