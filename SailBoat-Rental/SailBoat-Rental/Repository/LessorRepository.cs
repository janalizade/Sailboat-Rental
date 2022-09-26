using Sailboat_Rental.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SailBoat_Rental.Repository
{
    public class LessorRepository
    {
        private readonly IMongoCollection<Lessor> _lessors;
        
        public LessorRepository(IOptions<StoreSailboatDatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            this._lessors = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Lessor>(options.Value.LessorCollectionName);
            CreateIndex();

        }
        
        private async void CreateIndex()
        {
            await this._lessors.Indexes.CreateOneAsync(new CreateIndexModel<Lessor>(Builders<Lessor>.IndexKeys.Ascending(lessor => lessor.Name), new CreateIndexOptions { Unique = true }));
        }
        
        public Lessor Create(Lessor lessor)
        {
            this._lessors.InsertOne(lessor);
            return lessor;
        }

        public List<Lessor> GetLessors()
        {
            return this._lessors.Find(lessor => true).ToList();
        }
    }
}
