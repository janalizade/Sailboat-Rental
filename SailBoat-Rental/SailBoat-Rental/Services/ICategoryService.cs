using Sailboat_Rental.Models;
namespace SailBoat_Rental.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
         
          
        Category Create(Category category);
        
    }
}
