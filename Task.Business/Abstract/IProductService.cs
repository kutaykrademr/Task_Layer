using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Entities.Concrete;

namespace Task.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int productId);
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
    }
}
