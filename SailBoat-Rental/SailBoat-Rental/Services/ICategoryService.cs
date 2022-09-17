using Sailboat_Rental.Models;
namespace SailBoat_Rental.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategory(string id);       
        Category GetCategoryById(string id);   
        Category Create(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
