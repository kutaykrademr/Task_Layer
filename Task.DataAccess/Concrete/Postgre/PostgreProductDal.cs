using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DataAccess.EntityFramework;
using Task.DataAccess.Abstract;
using Task.DataAccess.Concrete.EntityFramework;
using Task.Entities.Concrete;

namespace Task.DataAccess.Concrete.Postgre
{
    public class PostgreProductDal : EfEntityRepositoryBase<Product, PostgreContext>, IProductDal
    {
    }
}
