using Microsoft.AspNetCore.Mvc;
using OnlineShop.ApplicationServices;
using OnlineShop.ApplicationServices.DTO;
using OnlineShop.ApplicationServices.Request;
using System.Net;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _productService.AddProductAsync(req);

            return Ok();
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(List<ProductDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrders()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
    }
}
