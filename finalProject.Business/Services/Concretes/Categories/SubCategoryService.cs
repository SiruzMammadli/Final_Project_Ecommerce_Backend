using finalProject.Business.Services.Abstracts.Categories;
using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Common.Wrappers.Responses.Concretes.ErrorResponses;
using finalProject.Common.Wrappers.Responses.Concretes.SuccessResponses;
using finalProject.DataAccess.Repositories.Abstracts.Categories;
using finalProject.Entities.Concretes.Categories;
using finalProject.Entities.DTOs.Categories;

namespace finalProject.Business.Services.Concretes.Categories
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public IDataResponse<IEnumerable<SubCategory_Dto>> GetAll()
        {
            IEnumerable<SubCategory> subcategories = _subCategoryRepository.GetAll();
            try
            {
                return new SuccessDataResponse<IEnumerable<SubCategory_Dto>>(subcategories.Select(sc => new SubCategory_Dto()
                {
                    Id = sc.Id.ToString(),
                    SubCategoryName = sc.SubCategoryName,
                    CategoryTypeId = sc.CategoryTypeId.ToString()
                }).ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResponse<IEnumerable<SubCategory_Dto>>(ex.Message);
            }
        }

        public IResponse Insert(AddSubCategory_Dto data)
        {
            try
            {
                _subCategoryRepository.Insert(new SubCategory()
                {
                    SubCategoryName = data.SubCategoryName,
                    CategoryTypeId = Guid.Parse(data.CategoryTypeId),
                });
                return new SuccessResponse("Alt kateqoriya uğurla əlavə olundu!");
            }
            catch (Exception ex)
            {
                return new ErrorResponse(ex.Message);
            }
        }
    }
}
