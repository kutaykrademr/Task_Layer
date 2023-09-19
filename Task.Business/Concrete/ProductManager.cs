using Task.Business.Abstract;
using Task.DataAccess.Abstract;
using Task.Entities.Concrete;

namespace Task.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetAll(x => x.CategoryId == categoryId);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(x => x.ProductId == productId);
        }
    }
}
