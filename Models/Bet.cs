using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
namespace Roulette_Api.Models
{
    public class Bet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("roulette_id")]
        [JsonPropertyName("roulette_id")]
        public string rouletteId { get; set; }
        [BsonElement("user_id")]
        [JsonPropertyName("user_id")]
        public string userId { get; set; }
        public int type { get; set; }
        public int target { get; set; }
        public decimal money { get; set; }
        public DateTime date { get; set; }
    }
}