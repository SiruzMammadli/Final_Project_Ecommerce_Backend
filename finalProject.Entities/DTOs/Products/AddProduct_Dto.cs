namespace finalProject.Entities.DTOs.Products
{
    public record struct AddProduct_Dto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercent { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string SubCategoryId { get; set; }
    }
}
