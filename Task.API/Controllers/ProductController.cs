using Helpers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Task.Business.Abstract;
using Task.Entities.Concrete;

namespace Task.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ProductListViewModel Get()
        {
            var products = _productService.GetAll();

            ProductListViewModel model = new ProductListViewModel
            {
                Products = products
            };

            return model;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var products = _productService.GetById(id);

            return products;  
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound(); // Ürün bulunamazsa 404 Not Found döndürülür.
            }

            _productService.Delete(id); // Ürünü silen bir metodu çağırın veya hizmet sınıfınıza uygun şekilde düzenleyin.

            return NoContent(); // Başarıyla silindiğinde 204 No Content döndürülür.
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                product.ProductId = 3;

                _productService.Add(product); 

                var addedProduct = product; 

                return Ok(addedProduct); 
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                return StatusCode(500, $"İç Sunucu Hatası: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productService.Update(product);
      
                var updatedProduct = product;

                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                return StatusCode(500, $"İç Sunucu Hatası: {ex.Message}");
            }
        }

    }
}
