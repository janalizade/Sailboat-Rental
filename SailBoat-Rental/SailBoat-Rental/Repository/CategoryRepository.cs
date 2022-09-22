using Sailboat_Rental.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SailBoat_Rental.Repository

{
    public class CategoryRepository
    {
        private readonly IMongoCollection<Category> _categories;
        public CategoryRepository(IOptions<StoreSailboatDatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _categories = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Category>(options.Value.CategoryCollectionName);

            CreateIndex();
        }

        private async void CreateIndex()
        {
            await _categories.Indexes.CreateOneAsync(new CreateIndexModel<Category>(Builders<Category>.IndexKeys.Ascending(category => category.CategoryName), new CreateIndexOptions { Unique = true }));
        }

        public Category Create(Category category)
        {
            _categories.InsertOne(category);
            return category;
        }


        public List<Category> GetCategories(string lessorId)
        {
            var lessorFilter = Builders<Category>.Filter.Eq(category => category.LessorId, lessorId);
            return _categories.Find(lessorFilter).ToList();
        }

        public Category GetCategory(string lessorId, string categoryId)
        {
            var lessorFilter = Builders<Category>.Filter.Eq(category => category.LessorId, lessorId);
            var categoryFilter = Builders<Category>.Filter.Eq(category => category.CategoryId, categoryId);
            var andFilter = Builders<Category>.Filter.And(lessorFilter, categoryFilter);
            return _categories.Find(andFilter).First();
        }
    }
}
