using Loady.Api.Core.Entities.Base;
using Loady.Api.Core.Helper;
using MongoDB.Bson.Serialization.Attributes;

namespace Loady.Api.Core.Entities
{
    [BsonCollection("Drivers")]
    public class Driver : BaseEntity
    {
        /// <summary>
        ///     Name of driver
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Surname of driver
        /// </summary>
        [BsonElement("surname")]
        public string Surname { get; set; }

        /// <summary>
        ///     Location of driver
        /// </summary>
        [BsonElement("location")]
        public Location Location { get; set; }

        /// <summary>
        ///     BirthDate of driver
        /// </summary>
        [BsonElement("birth_date")]
        public string BirthDate { get; set; }
    }
}