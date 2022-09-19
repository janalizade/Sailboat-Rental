using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Models;
using SailBoat_Rental.Services;

namespace SailBoat_Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;
        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            return categoryService.GetCategories();
        }



        // POST api/<CategoryController>
        [HttpPost]
        public ActionResult Post([FromBody] Category category)
        {
            categoryService.Create(category);
            return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);
        }


    }
}
