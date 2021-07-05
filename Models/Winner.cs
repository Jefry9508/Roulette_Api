using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
namespace Roulette_Api.Models
{
    public class Winner
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
        [BsonElement("bet_type")]
        [JsonPropertyName("bet_type")]
        public int betType { get; set; }

        [BsonElement("bet_target")]
        [JsonPropertyName("bet_target")]
        public int betTarget { get; set; }
        [BsonElement("earned_money")]
        [JsonPropertyName("earned_money")]
        public decimal earnedMoney { get; set; }
        public DateTime date { get; set; }
    }
}