using finalProject.Business.Services.Abstracts.Categories;
using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Common.Wrappers.Responses.Concretes.ErrorResponses;
using finalProject.Common.Wrappers.Responses.Concretes.SuccessResponses;
using finalProject.DataAccess.Repositories.Abstracts.Categories;
using finalProject.Entities.Concretes.Categories;
using finalProject.Entities.DTOs.Categories;

namespace finalProject.Business.Services.Concretes.Categories
{
    public class CategoryTypeService : ICategoryTypeService
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;

        public CategoryTypeService(ICategoryTypeRepository categoryTypeRepository)
        {
            _categoryTypeRepository = categoryTypeRepository;
        }

        public IResponse Insert(AddCategoryType_Dto data)
        {
            try
            {
                _categoryTypeRepository.Insert(new CategoryType()
                {
                    TypeName = data.TypeName,
                });
                return new SuccessResponse("Kateqoriya uğurla əlavə edildi!");
            }
            catch (Exception ex)
            {
                return new ErrorResponse($"Kateqoriya əlavə edilən zaman gözlənilməz bir xəta baş verdi!\n {ex.Message}");
            }
        }
    }
}
