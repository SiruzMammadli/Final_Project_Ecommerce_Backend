using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Entities.DTOs.Categories;

namespace finalProject.Business.Services.Abstracts.Categories
{
    public interface ISubCategoryService
    {
        IResponse Insert(AddSubCategory_Dto data);
        IDataResponse<IEnumerable<SubCategory_Dto>> GetAll();
    }
}
