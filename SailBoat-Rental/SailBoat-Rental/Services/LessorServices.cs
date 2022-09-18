using Sailboat_Rental.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SailBoat_Rental.Services
{
   
    public class LessorServices
    {
        private readonly IMongoCollection<Lessor> _lessors;
        public LessorServices(IOptions<StoreSailboatDatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _lessors = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Lessor>(options.Value.LessorCollectionName);
            CreateIndex();

        }
        private async void CreateIndex()
        {
            await _lessors.Indexes.CreateOneAsync(new CreateIndexModel<Lessor>(Builders<Lessor>.IndexKeys.Ascending(lessor => lessor.Name), new CreateIndexOptions { Unique = true }));
        }
        public Lessor Create(Lessor lessor)
        {
            _lessors.InsertOne(lessor);
            return lessor;
        }


        public List<Lessor> GetLessors()
        {
            return _lessors.Find(lessor => true).ToList();
        }
    }
   
}
