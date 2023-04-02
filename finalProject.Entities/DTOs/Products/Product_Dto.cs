namespace finalProject.Entities.DTOs.Products
{
    public struct Product_Dto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercent { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsStock { get; set; }
        public bool FreeDelivery { get; set; }
        public string SubCategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
