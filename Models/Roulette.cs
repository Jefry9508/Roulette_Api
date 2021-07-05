using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace Roulette_Api.Models
{
    public class Roulette
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido para la creación de la ruleta")]
        public string name { get; set; }
        public Boolean state { get; set; }
        [BsonElement("current_game_id")]
        [JsonPropertyName("current_game_id")]
        public string currentGameId { get; set; }
        [BsonElement("creation_date")]
        [JsonPropertyName("creation_date")]
        public DateTime creationDate { get; set; }
        [BsonElement("last_update")]
        [JsonPropertyName("last_update")]
        public DateTime lastUpdate { get; set; }
    }
}