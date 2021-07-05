using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Roulette_Api.Models
{
    public class Winner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("roulette_id")]
        public string RouletteId { get; set; }
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("bet_type")]
        public int BetType { get; set; }
        [BsonElement("bet_target")]
        public int BetTarget { get; set; }
        [BsonElement("earned_money")]
        public decimal EarnedMoney { get; set; }
        public DateTime Date { get; set; }
    }
}