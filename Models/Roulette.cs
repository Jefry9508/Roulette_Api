using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
namespace Roulette_Api.Models
{
    public class Roulette
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string name { get; set; }
        public Boolean state { get; set; }
        [BsonElement("creation_date")]
        [JsonPropertyName("creation_date")]
        public DateTime creationDate { get; set; }
        [BsonElement("last_update")]
        [JsonPropertyName("last_update")]
        public DateTime lastUpdate { get; set; }
    }
    
}