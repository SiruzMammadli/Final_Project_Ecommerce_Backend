using finalProject.Business.Services.Abstracts.Products;
using finalProject.DataAccess.Repositories.Abstracts.Products;
using finalProject.Entities.Concretes.Products;
using finalProject.Entities.DTOs.Products;

namespace finalProject.Business.Services.Concretes.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Insert(AddProduct_Dto data)
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
                    SubCategoryId = data.SubCategoryId,
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<GetProduct_Dto> GetAllProducts()
        {
            try
            {
                IEnumerable<Product> products = _productRepository.GetAll();
                return products.Select(p => new GetProduct_Dto()
                {
                    Id = p.Id.ToString(),
                    ProductName = p.ProductName,
                    Price = p.Price,
                    DiscountPercent = p.DiscountPercent,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    SubCategoryId = p.SubCategoryId,
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
