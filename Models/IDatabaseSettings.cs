namespace Roulette_Api.Models
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string RoulettesCollectionName { get; set; }
        string BetsCollectionName { get; set; }
        string WinnersCollectionName { get; set; }
    }
}