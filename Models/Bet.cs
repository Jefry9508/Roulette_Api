using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "El Id de la ruleta es requerido.")]
        public string rouletteId { get; set; }
        [BsonElement("user_id")]
        [JsonPropertyName("user_id")]
        public string userId { get; set; }
        [Required(ErrorMessage = "El tipo de apuesta es requerido (Número o color).")]
        [Range(0, 1, ErrorMessage = "Tipo de apuesta incorrecto. Debe ser rojo (o) o negro (1).")]
        public int type { get; set; }
        [BsonElement("game_id")]
        [JsonPropertyName("game_id")]
        public string gameId { get; set; }
        [Required(ErrorMessage = "El objetivo de la apuesta es requerido (Número, rojo o negro.)")]
        [Range(0, 36, ErrorMessage = "Objetivo de apuesta incorrecto.")]
        public int target { get; set; }
        [Required(ErrorMessage = "El dinero a apostar es requerido.")]
        [Range(0.1, 10000, ErrorMessage = "El dinero apostado debe estar entre ${1} US y ${2} US.")]
        public decimal money { get; set; }
        public DateTime date { get; set; }
    }
}