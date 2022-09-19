using Sailboat_Rental.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SailBoat_Rental.Services

{
    public class CategoryService 
    {
        private readonly IMongoCollection<Category> _categories;
        public CategoryService(IOptions<StoreSailboatDatabaseSetting> options) {
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

     
        public List<Category> GetCategories()
        {
             return _categories.Find(category=>true).ToList();
        }

        
    }
}
