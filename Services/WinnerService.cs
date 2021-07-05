using Roulette_Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace Roulette_Api.Services
{
    public class WinnerService
    {
        private readonly IMongoCollection<Winner> _winners;
        public WinnerService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _winners = database.GetCollection<Winner>(settings.WinnersCollectionName);
        }
        public Winner Create(Winner winner)
        {
            _winners.InsertOne(winner);
            return winner;
        }
        public List<Winner> Get() =>
            _winners.Find(winner => true).ToList();
        public Winner Get(string id) =>
            _winners.Find<Winner>(winner => winner.Id == id).FirstOrDefault();
        public void Update(string id, Winner winnerIn) =>
            _winners.ReplaceOne(winner => winner.Id == id, winnerIn);
        public List<Winner> GetByGameId(string gameId) =>
            _winners.Find<Winner>(winner => winner.gameId == gameId).ToList();
    }
}