using MongoDB.Bson.Serialization.Attributes;

namespace Loady.Api.Core.Entities
{
    public class Location
    {
        /// <summary>
        ///     City name of Location
        /// </summary>
        [BsonElement("city")]
        public string City { get; set; }

        /// <summary>
        ///    Country name of Location
        /// </summary>
        [BsonElement("country")]
        public string Country { get; set; }

        /// <summary>
        ///     Latitude of Location
        /// </summary>
        [BsonElement("latitude")]
        public string Latitude { get; set; }

        /// <summary>
        ///     Longitude of location
        /// </summary>
        [BsonElement("longitude")]
        public string Longitude { get; set; }
    }
}