using Sailboat_Rental.Models;
using MongoDB.Driver;

namespace SailBoat_Rental.Services

{
    public class CategoryService :ICategoryService
    {
        private readonly IMongoCollection<Category> _categories;
        public CategoryService(IStoreSailboatDatabaseSetting settings,IMongoClient mongoClient)
        { 
            
            var database=mongoClient.GetDatabase(settings.DatabaseName);
            _categories = database.GetCollection<Category>(settings.SailBoatCollectionName);
        }

        public Category Create(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(string id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(string id)
        {
            throw new NotImplementedException();
        }

        public Category Update(string id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
