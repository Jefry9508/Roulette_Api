using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Roulette_Api.Models
{
    public class Bet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("roulette_id")]
        public string RouletteId { get; set; }
        [BsonElement("user_id")]
        public string UserId { get; set; }
        public int Type { get; set; }
        public int Target { get; set; }
        public decimal Money { get; set; }
        public DateTime Date { get; set; }
    }
}