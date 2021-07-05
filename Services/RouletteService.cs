using Roulette_Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace Roulette_Api.Services
{
    public class RouletteService
    {
        private readonly IMongoCollection<Roulette> _roulettes;
        public RouletteService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _roulettes = database.GetCollection<Roulette>(settings.RoulettesCollectionName);
        }
        public Roulette Create(Roulette roulette)
        {
            _roulettes.InsertOne(roulette);
            return roulette;
        }
        public List<Roulette> Get() =>
            _roulettes.Find(roulette => true).ToList();
        public Roulette Get(string id) =>
            _roulettes.Find<Roulette>(roulette => roulette.Id == id).FirstOrDefault();
        public void Update(string id, Roulette rouletteIn) =>
            _roulettes.ReplaceOne(roulette => roulette.Id == id, rouletteIn);
    }
}