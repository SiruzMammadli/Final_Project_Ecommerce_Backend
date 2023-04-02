using finalProject.Business.Services.Abstracts.Categories;
using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Entities.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.API.Controllers.Admin.Categories
{
    [Route("api/admin/subcategories")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpPost("add")]
        public IActionResult Add(AddSubCategory_Dto data)
        {
            if (data.SubCategoryName is not null && data.CategoryTypeId is not null)
            {
                _subCategoryService.Insert(data);
                return Ok();
            }
            return BadRequest("Doldurulmayan xanə var!");
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            IDataResponse<IEnumerable<SubCategory_Dto>> subcategories = _subCategoryService.GetAll();
            return Ok(subcategories);
        }
    }
}
