using finalProject.Common.Entities.Concretes;
using finalProject.Common.Repositories.MongoDb.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace finalProject.Entities.Concretes.Products
{
    [BsonCollection("products")]
    public class Product : MongoEntity
    {
        public string ProductName { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public int DiscountPercent { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string SubCategoryId { get; set; }
    }
}
