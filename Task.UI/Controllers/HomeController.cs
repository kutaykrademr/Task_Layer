using Helpers.Models;
using Helpers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task.UI.Models;

namespace Task.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new ProductListViewModel();

            try
            {
                model = Helpers.Serializers.DeserializeJson<ProductListViewModel>(Helpers.Request.Get(Mutuals.ApiUrl + "Product"));
            }
            catch (Exception)
            {
                model = new ProductListViewModel();
            }

            return View(model);
        }

        public JsonResult GetProductById(int id)
        {
            var model = new Product();

            try
            {
                model = Helpers.Serializers.DeserializeJson<Product>(Helpers.Request.Get(Mutuals.ApiUrl + "Product/" + id));
            }
            catch (Exception)
            {
                model = new Product();
            }

            return Json(model);
        }

        public SimpleResponse DeleteProduct(int id)
        {
            SimpleResponse resp = new SimpleResponse();
            var model = new Product();
         
            try
            {
                model = Helpers.Serializers.DeserializeJson<Product>(Helpers.Request.Delete(Mutuals.ApiUrl + "Product/" + id));
                resp.Success = true;
            }
            catch (Exception)
            {
                model = new Product();
                resp.Success = false;
            }

            return resp;
        }

        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Ürün verileri geçersiz.");
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PutAsJsonAsync(Mutuals.ApiUrl + "Product", product);

                    if (response.IsSuccessStatusCode)
                    {
                        var sonuc = await response.Content.ReadAsStreamAsync();
                        return Ok(sonuc);
                    }
                    else
                    {
                        var hataIcerik = await response.Content.ReadAsStringAsync();
                        return BadRequest($"Ürün güncelleme başarısız oldu. API bir hata döndürdü: {hataIcerik}");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç Sunucu Hatası: {ex.Message}");
            }
        }

        public async Task<IActionResult> AddProduct(Product product)
        {

            if (product == null)
            {
                return BadRequest("Product data is invalid.");
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
           
                    var response = await client.PostAsJsonAsync(Mutuals.ApiUrl + "Product", product);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStreamAsync();
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest("Failed to create product. API returned an error.");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}