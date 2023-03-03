using finalProject.Common.Entities.Abstracts;
using MongoDB.Bson;

namespace finalProject.Common.Entities.Concretes
{
    public class MongoEntity : IMongoEntity
    {
        public ObjectId Id { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
