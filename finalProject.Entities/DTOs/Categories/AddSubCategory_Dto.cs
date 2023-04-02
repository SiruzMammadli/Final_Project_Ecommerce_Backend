namespace finalProject.Entities.DTOs.Categories
{
    public record struct AddSubCategory_Dto
    {
        public string SubCategoryName { get; set; }
        public string CategoryTypeId { get; set; }
    }
}
