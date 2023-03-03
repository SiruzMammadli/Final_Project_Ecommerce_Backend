using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace finalProject.Common.Entities.Abstracts
{
    public interface IMongoEntity
    {
        [BsonId]
        ObjectId Id { get; set; }
        DateTime? UpdatedAt { get; set; }
        DateTime CreatedAt { get; init; }
        bool IsDeleted { get; set; }
    }
}
