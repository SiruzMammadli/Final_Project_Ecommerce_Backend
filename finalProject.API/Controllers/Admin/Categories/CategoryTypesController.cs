using finalProject.Business.Services.Abstracts.Categories;
using finalProject.Entities.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.API.Controllers.Admin.Categories
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CategoryTypesController : ControllerBase
    {
        private readonly ICategoryTypeService _categoryTypeService;

        public CategoryTypesController(ICategoryTypeService categoryTypeService)
        {
            _categoryTypeService = categoryTypeService;
        }

        [HttpPost("add")]
        public IActionResult Add(AddCategoryType_Dto data)
        {
            if (data != null)
            {
                _categoryTypeService.Insert(data);
                return Ok();
            }
            return BadRequest();
        }
    }
}
