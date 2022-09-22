using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Model;
using SailBoat_Rental.Service;

namespace SailBoat_Rental.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;
        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Produces("application/json")]
        [HttpGet("lessorId/{lessorId}/")]
        public ActionResult<List<Category>> GetAll(string lessorId)
        {
            return categoryService.GetCategories(lessorId);
        }

        [Produces("application/json")]
        [HttpGet("lessorId/{lessorId}/categoryId/{categoryId}")]
        public ActionResult<Category> GetOne(string lessorId, string categoryId)
        {
           return categoryService.GetCategory(lessorId, categoryId);
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("lessorId/{lessorId}")]
        public ActionResult<Category> Create(string lessorId, [FromBody] Category category)
        {
            category.LessorId = lessorId;
            return categoryService.Create(category);
        }
    }
}
