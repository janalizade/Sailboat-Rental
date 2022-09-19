using Sailboat_Rental.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SailBoat_Rental.Services
{

    public class BoatService
    {
        private readonly IMongoCollection<Boat> _boats;
        public BoatService(IOptions<StoreSailboatDatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _boats = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Boat>(options.Value.BoatCollectionName);
            CreateIndex();
        }
        private async void CreateIndex()
        {
            await _boats.Indexes.CreateOneAsync(new CreateIndexModel<Boat>(Builders<Boat>.IndexKeys.Ascending(boat => boat.Number), new CreateIndexOptions { Unique = true }));
        }
        public Boat Create(Boat boat)
        {
            _boats.InsertOne(boat);
            return boat;
        }


        public List<Boat> GetBoats()
        {
            return _boats.Find(boat => true).ToList();
        }
    }
}
