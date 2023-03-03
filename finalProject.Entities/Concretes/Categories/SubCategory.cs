using finalProject.Common.Entities.Concretes;

namespace finalProject.Entities.Concretes.Categories
{
    public class SubCategory : BaseEntity
    {
        public string SubCategoryName { get; set; }
        public Guid CategoryTypeId { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}
