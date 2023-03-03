using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Entities.DTOs.Categories;

namespace finalProject.Business.Services.Abstracts.Categories
{
    public interface ICategoryTypeService
    {
        IResponse Insert(AddCategoryType_Dto data);
    }
}
