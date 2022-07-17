using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Dto;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDto obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productService.AddProduct(obj);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var res = _productService.GetProducts();
            return Ok(res);
        }


    }
}