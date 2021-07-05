namespace Roulette_Api.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string RoulettesCollectionName { get; set; }
        public string BetsCollectionName { get; set; }
        public string WinnersCollectionName { get; set; }
    }
}