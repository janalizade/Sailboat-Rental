using Sailboat_Rental.Models;
using MongoDB.Driver;
namespace SailBoat_Rental.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IMongoCollection<Category> _categories;
        public CategoryService(IStoreSailboatDatabaseSetting settings,IMongoClient mongoClient)
        { 
            
            var database=mongoClient.GetDatabase(settings.DatabaseName);
            _categories = database.GetCollection<Category>(settings.SailBoatCollectionName);
        }
        public List<Category> GetCategories()
        {
            return _categories.Find(category=>true).ToList();
        }
        Category GetCategoryById(string id)
        {
            return _categories.Find(category => category.CategoryId==id).FirstOrDefault();
        }
    
        public Category Create(Category category)
        {
            _categories.InsertOne(category);
            return category;
        }
        void Update(string id,Category category)
        {
            _categories.ReplaceOne(category => category.CategoryId == id,category);
        }
        void Remove(string id)
        {
            _categories.DeleteOne(category => category.CategoryId == id);
        }
    }
}
