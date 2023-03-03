using finalProject.Common.Repositories.MongoDb;
using finalProject.Common.Repositories.MongoDb.Settings;
using finalProject.DataAccess.Repositories.Abstracts.Products;
using finalProject.Entities.Concretes.Products;

namespace finalProject.DataAccess.Repositories.Concretes.Products
{
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoDbSettings dbSettings) : base(dbSettings)
        {
        }
    }
}
