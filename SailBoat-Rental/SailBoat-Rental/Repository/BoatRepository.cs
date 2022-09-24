using Sailboat_Rental.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SailBoat_Rental.Repository
{
    public class BoatRepository
    {
        private readonly IMongoCollection<Boat> _boats;
        public BoatRepository(IOptions<StoreSailboatDatabaseSetting> options)
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

        public List<Boat> GetBoatByLessorId(string lessorId)
        {
            var lessorFilter = Builders<Boat>.Filter.Eq(boat => boat.LessorId, lessorId);
            return _boats.Find(lessorFilter).ToList();
        }

        public Boat GetBoat(string lessorId, string categoryId)
        {
            var lessorFilter = Builders<Boat>.Filter.Eq(boat => boat.LessorId, lessorId);
            var categoryFilter = Builders<Boat>.Filter.Eq(boat => boat.CategoryId, categoryId);
            var andFilter = Builders<Boat>.Filter.And(lessorFilter, categoryFilter);
            return _boats.Find(andFilter).First();
        }
    }
}
