using finalProject.Common.Repositories.Abstracts;
using finalProject.Entities.Concretes.Products;

namespace finalProject.DataAccess.Repositories.Abstracts.Products
{
    public interface IProductRepository : IMongoRepository<Product>
    {
    }
}
