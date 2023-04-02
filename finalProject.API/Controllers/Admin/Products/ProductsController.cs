using finalProject.Business.Services.Abstracts.Products;
using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Entities.DTOs.Products;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.API.Controllers.Admin.Products
{
    [Route("api/admin/products")]
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
            IDataResponse<IEnumerable<Product_Dto>> products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("get_by_id/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            if (id is not null)
            {
                IDataResponse<Product_Dto> product = await _productService.GetProductByIdAsync(id);
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpPost("remove")]
        public async Task<IActionResult> Remove(RemoveProduct_Dto data)
        {
            if (data.Id is not null)
            {
                await _productService.RemoveAsync(data);
                return Ok();
            }
            return BadRequest();
        }
    }
}
