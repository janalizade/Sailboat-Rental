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

        public List<Category> GetCategories(string lessorId)
        {
            return this.categoryRepository.GetCategories(lessorId);
        }


        public Category GetCategory(string lessorId, string categoryId)
        {
            return this.categoryRepository.GetCategory(lessorId, categoryId);
        }


        public Category Create(Category category)
        {
            return this.categoryRepository.Create(category);
        }
    }
}