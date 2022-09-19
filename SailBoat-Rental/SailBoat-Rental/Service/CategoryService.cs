using Sailboat_Rental.Model;
using SailBoat_Rental.Repository;

namespace SailBoat_Rental.Service
{
    public class CategoryService
    {
        private CategoryRepository categoryRepository;
        public CategoryService(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories()
        {
            return categoryRepository.GetCategories();
        }

        public Category Create(Category category)
        {
            return categoryRepository.Create(category);
        }
    }
}