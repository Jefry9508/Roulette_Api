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
        public List<Bet> FindWinningBets(string gameId, int winningNumber) =>    
            _bets.Find<Bet>(bet => (bet.type == 0 && bet.target == winningNumber) ||
                (bet.type == 1 && bet.target == winningNumber%2)).ToList();
    }
}