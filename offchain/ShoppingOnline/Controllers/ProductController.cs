using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> productList = new List<Product>
        {
            new Product
            {
                ProductId = "P01",
                Name = "iPhone 13 Pro Max",
                ImageUrl = "https://cdn-img.wemall.com/943745/w_1400,h_1400,c_thumb/9267183767dd31b145c790f281cd806d/iphone_13_pro_max_pdp_position-1a_color_gold__th.jpg",
                Price = 10,
            },
            new Product
             {
                ProductId = "P02",
                Name = "Xiaomi Mi Air Purifier 3H",
                ImageUrl = "https://image.makewebeasy.net/makeweb/0/jxlPpOYv8/AirPurifier/4007433_1.jpg",
                Price = 3,
            },
            new Product
             {
                ProductId = "P03",
                Name = "APPLE Watch Series 7 GPS",
                ImageUrl = "https://d1dtruvuor2iuy.cloudfront.net/media/catalog/product/a/p/apple_watch_series_7_gps_45mm_starlight_aluminum_starlight_sport_band_pdp_image_position-1__th_1.jpg",
                Price = 5,
            },
        };

        // GET: api/<ShoppingController>
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return productList;
        }

        // GET api/<ShoppingController>/5
        [HttpGet("{id}")]
        public Product GetProductById(string id)
        {
            var product = productList.FirstOrDefault(it => it.ProductId == id);
            return product;
        }
    }
}
