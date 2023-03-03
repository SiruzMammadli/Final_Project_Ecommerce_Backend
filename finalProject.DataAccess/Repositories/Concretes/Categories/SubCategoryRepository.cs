using finalProject.Common.Repositories.EntityFramework;
using finalProject.DataAccess.Contexts;
using finalProject.DataAccess.Repositories.Abstracts.Categories;
using finalProject.Entities.Concretes.Categories;

namespace finalProject.DataAccess.Repositories.Concretes.Categories
{
    public class SubCategoryRepository : EfRepository<SubCategory, ApplicationDbContext>, ISubCategoryRepository
    {
    }
}
