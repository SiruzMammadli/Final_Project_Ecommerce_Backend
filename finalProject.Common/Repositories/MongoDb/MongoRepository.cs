using finalProject.Common.Entities.Abstracts;
using finalProject.Common.Repositories.Abstracts;
using finalProject.Common.Repositories.MongoDb.Attributes;
using finalProject.Common.Repositories.MongoDb.Settings;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace finalProject.Common.Repositories.MongoDb
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : class, IMongoEntity
    {
        private readonly IMongoCollection<TDocument> _collection;

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        public MongoRepository(IMongoDbSettings dbSettings)
        {
            IMongoDatabase db = new MongoClient(dbSettings.ConnectionString).GetDatabase(dbSettings.DatabaseName);
            _collection = db.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        public void Insert(TDocument data)
        {
            _collection.InsertOne(data);
        }
        public async Task InsertAsync(TDocument data)
        {
            await _collection.InsertOneAsync(data);
        }
        public void Update(TDocument data)
        {
            FilterDefinition<TDocument> filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, data.Id);
            _collection.ReplaceOne(filter, data);
        }
        public async Task UpdateAsync(TDocument data)
        {
            FilterDefinition<TDocument> filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, data.Id);
            await _collection.ReplaceOneAsync(filter, data);
        }
        public IEnumerable<TDocument> GetAll()
        {
            return _collection.Find(x => x.IsDeleted.Equals(false)).ToEnumerable();
        }

        public IEnumerable<TDocument> GetWhere(Expression<Func<TDocument, bool>> filter)
        {
            return _collection.Find(filter).ToEnumerable();
        }
    }
}
