using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Model;
using SailBoat_Rental.Service;

namespace SailBoat_Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessorController : ControllerBase
    {
        private readonly LessorService lessorService;
        public LessorController(LessorService lessorService)
        {
            this.lessorService = lessorService;
        }
        // GET: api/<LessorController>
        [HttpGet]
        public ActionResult<List<Lessor>> Get()
        {
            return lessorService.GetLessors();
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
            lessorService.Create(lessor);
            return CreatedAtAction(nameof(Get), new { id = lessor.Id }, lessor);
        }


    }
}
