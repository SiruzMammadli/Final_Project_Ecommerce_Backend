using finalProject.Business.Services.Abstracts.Products;
using finalProject.Entities.DTOs.Products;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.API.Controllers.Admin.Products
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public IActionResult Insert(AddProduct_Dto data)
        {
            if (data != null)
            {
                _productService.Insert(data);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            IEnumerable<GetProduct_Dto> products = _productService.GetAllProducts();

            if(products is not null)
            {
                return Ok(products);
            }
            return BadRequest();
        }
    }
}
