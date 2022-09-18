using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Models;
using SailBoat_Rental.Services;

namespace SailBoat_Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessorController : ControllerBase
    {
        private readonly LessorServices lessorServices;
        public LessorController(LessorServices lessorServices)
        {
            this.lessorServices = lessorServices;
        }
        // GET: api/<LessorController>
        [HttpGet]
        public ActionResult<List<Lessor>> Get()
        {
            return lessorServices.GetLessors();
        }
        
        // GET api/<LessorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LessorController>
        [HttpPost]
        public ActionResult Post( Lessor lessor)
        {
            lessorServices.Create(lessor);
            return CreatedAtAction(nameof(Get), new { id = lessor.Id }, lessor);
        }


    }
}
