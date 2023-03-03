using finalProject.Entities.DTOs.Products;

namespace finalProject.Business.Services.Abstracts.Products
{
    public interface IProductService
    {
        void Insert(AddProduct_Dto data);

        IEnumerable<GetProduct_Dto> GetAllProducts();
    }
}
