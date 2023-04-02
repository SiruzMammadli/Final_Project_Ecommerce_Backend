using finalProject.Business.Services.Abstracts.Categories;
using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Entities.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.API.Controllers.Admin.Categories
{
    [Route("api/admin/categorytypes")]
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
            if (data.TypeName is not null)
            {
                _categoryTypeService.Insert(data);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            IDataResponse<IEnumerable<CategoryType_Dto>> category_types = _categoryTypeService.GetAll();

            return Ok(category_types);
        }
    }
}
