using Roulette_Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace Roulette_Api.Services
{
    public class BetService
    {
        private readonly IMongoCollection<Bet> _bets;
        public BetService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _bets = database.GetCollection<Bet>(settings.BetsCollectionName);
        }
        public Bet Create(Bet bet)
        {
            _bets.InsertOne(bet);
            return bet;
        }
        public List<Bet> Get() =>
            _bets.Find(bet => true).ToList();
        public Bet Get(string id) =>
            _bets.Find<Bet>(bet => bet.Id == id).FirstOrDefault();
        public void Update(string id, Bet betIn) =>
            _bets.ReplaceOne(bet => bet.Id == id, betIn);
        public void Remove(Bet betIn) =>
            _bets.DeleteOne(bet => bet.Id == betIn.Id);
        public void Remove(string id) => 
            _bets.DeleteOne(bet => bet.Id == id);
    }
}