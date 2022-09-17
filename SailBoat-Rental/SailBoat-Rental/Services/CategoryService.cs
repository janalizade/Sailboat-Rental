using Sailboat_Rental.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SailBoat_Rental.Services

{
    public class CategoryService 
    {
        private readonly IMongoCollection<Category> _categories;
        //  public CategoryService(IStoreSailboatDatabaseSetting settings,IMongoClient mongoClient)
        //  { 

        //      var database=mongoClient.GetDatabase(settings.DatabaseName);
        //      _categories = database.GetCollection<Category>(settings.CollectionName);
        //  }
        public CategoryService(IOptions<StoreSailboatDatabaseSetting> options) {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _categories = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Category>(options.Value.CollectionName);
      //  { 

        //      var database=mongoClient.GetDatabase(settings.DatabaseName);
        //      _categories = database.GetCollection<Category>(settings.CollectionName);
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
