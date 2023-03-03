using finalProject.Common.Entities.Concretes;

namespace finalProject.Entities.Concretes.Categories
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
