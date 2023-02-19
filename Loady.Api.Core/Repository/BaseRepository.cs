using Loady.Api.Core.Entities.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq.Expressions;
using Loady.Api.Core.Helper;

namespace Loady.Api.Core.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(
            MongoClient mongoClient,
            IConfiguration configuration)
        {
            _mongoClient = mongoClient;
            _database = mongoClient.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            _collection = _database.GetCollection<T>(GetCollectionName(typeof(T)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public async Task<T> GetById(string id)
        {
            var entity = await _collection.FindAsync(x => x.Id == id);

            return entity.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            var entities = await _collection.FindAsync(filterExpression);

            return entities.ToList();
        }
    }
}