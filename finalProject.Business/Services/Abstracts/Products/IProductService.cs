using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Entities.DTOs.Products;

namespace finalProject.Business.Services.Abstracts.Products
{
    public interface IProductService
    {
        IResponse Insert(AddProduct_Dto data);
        Task<IResponse> RemoveAsync(RemoveProduct_Dto data);
        IDataResponse<IEnumerable<Product_Dto>> GetAllProducts();
        Task<IDataResponse<Product_Dto>> GetProductByIdAsync(string id);
    }
}
