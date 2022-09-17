using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Models;
using SailBoat_Rental.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public void Post([FromBody] string value)
        {
        }


    }
}
