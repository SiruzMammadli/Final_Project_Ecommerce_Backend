namespace finalProject.Entities.DTOs.Products
{
    public record struct RemoveProduct_Dto
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
