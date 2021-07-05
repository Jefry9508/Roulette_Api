using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "El Id de la ruleta es requerido.")]
        public string rouletteId { get; set; }
        [BsonElement("user_id")]
        [JsonPropertyName("user_id")]
        public string userId { get; set; }
        [BsonElement("game_id")]
        [JsonPropertyName("game_id")]
        public string gameId { get; set; }
        [BsonElement("bet_type")]
        [JsonPropertyName("bet_type")]
        [Required(ErrorMessage = "El tipo de apuesta es requerido (Número o color).")]
        [Range(0, 1, ErrorMessage = "Tipo de apuesta incorrecto. Debe ser rojo (o) o negro (1).")]
        public int betType { get; set; }

        [BsonElement("bet_target")]
        [JsonPropertyName("bet_target")]
        [Required(ErrorMessage = "El objetivo de la apuesta es requerido (Número, rojo o negro.)")]
        [Range(0, 36, ErrorMessage = "Objetivo de apuesta incorrecto.")]
        public int betTarget { get; set; }
        [BsonElement("winnig_number")]
        [JsonPropertyName("winnig_number")]
        public int winningNumber { get; set; }
        [BsonElement("earned_money")]
        [JsonPropertyName("earned_money")]
        [Required(ErrorMessage = "El dinero ganado por el usuario es requerido.")]
        public decimal earnedMoney { get; set; }
        public DateTime date { get; set; }
    }
}