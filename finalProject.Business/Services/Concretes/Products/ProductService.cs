using finalProject.Business.Services.Abstracts.Products;
using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Common.Wrappers.Responses.Concretes.ErrorResponses;
using finalProject.Common.Wrappers.Responses.Concretes.SuccessResponses;
using finalProject.DataAccess.Repositories.Abstracts.Products;
using finalProject.Entities.Concretes.Products;
using finalProject.Entities.DTOs.Products;
using MongoDB.Bson;

namespace finalProject.Business.Services.Concretes.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IResponse Insert(AddProduct_Dto data)
        {
            try
            {
                _productRepository.Insert(new Product()
                {
                    ProductName = data.ProductName,
                    Price = data.Price,
                    DiscountPercent = data.DiscountPercent,
                    Description = data.Description,
                    ImageUrl = data.ImageUrl,
                    IsStock = data.IsStock,
                    FreeDelivery = data.FreeDelivery,
                    SubCategoryId = data.SubCategoryId,
                });
                return new SuccessResponse("Məhsul uğurla əlavə edildi!");
            }
            catch (Exception ex)
            {
                return new ErrorResponse(ex.Message);
            }
        }
        public async Task<IResponse> RemoveAsync(RemoveProduct_Dto data)
        {
            try
            {
                await _productRepository.UpdateAsync(new Product()
                {
                    Id = ObjectId.Parse(data.Id),
                    IsDeleted = data.IsDeleted
                });
                return new SuccessResponse("Məhsul silindi!");
            }
            catch (Exception ex)
            {
                return new ErrorResponse(ex.Message);
            }
        }
        public IDataResponse<IEnumerable<Product_Dto>> GetAllProducts()
        {
            try
            {
                IEnumerable<Product> products = _productRepository.GetAll();
                return new SuccessDataResponse<IEnumerable<Product_Dto>>(products.Select(p => new Product_Dto()
                {
                    Id = p.Id.ToString(),
                    ProductName = p.ProductName,
                    Price = p.Price,
                    DiscountPercent = p.DiscountPercent,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    IsStock = p.IsStock,
                    FreeDelivery = p.FreeDelivery,
                    SubCategoryId = p.SubCategoryId,
                    IsDeleted = p.IsDeleted
                }).ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResponse<IEnumerable<Product_Dto>>(ex.Message);
            }
        }
        public async Task<IDataResponse<Product_Dto>> GetProductByIdAsync(string id)
        {
            try
            {
                Product product = await _productRepository.GetByIdAsync(id);
                return new SuccessDataResponse<Product_Dto>(new Product_Dto()
                {
                    Id = product.Id.ToString(),
                    ProductName = product.ProductName,
                    Price = product.Price,
                    DiscountPercent = product.DiscountPercent,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    IsStock = product.IsStock,
                    FreeDelivery = product.FreeDelivery,
                    SubCategoryId = product.SubCategoryId,
                    IsDeleted = product.IsDeleted
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResponse<Product_Dto>(ex.Message);
            }
        }
    }
}
