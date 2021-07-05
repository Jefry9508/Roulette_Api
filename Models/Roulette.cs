using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Roulette_Api.Models
{
    public class Roulette
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        [BsonElement("creation_date")]
        public DateTime CreationDate { get; set; }
        [BsonElement("last_update")]
        public DateTime LastUpdate { get; set; }
    }
    
}