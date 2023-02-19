using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Loady.Api.Core.Entities.Base
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
