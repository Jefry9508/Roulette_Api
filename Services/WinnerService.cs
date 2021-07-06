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
            var client = new MongoClient(connectionString: settings.ConnectionString);
            var database = client.GetDatabase(name: settings.DatabaseName);
            _winners = database.GetCollection<Winner>(name: settings.WinnersCollectionName);
        }
        public Winner Create(Winner winner)
        {
            _winners.InsertOne(document: winner);
            return winner;
        }
        public List<Winner> GetByGameId(string gameId) =>
            _winners.Find<Winner>(winner => winner.gameId == gameId).ToList();
    }
}