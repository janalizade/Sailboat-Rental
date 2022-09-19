using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Models;
using SailBoat_Rental.Services;

namespace SailBoat_Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        private readonly BoatService boatService;
        public BoatController(BoatService boatService)
        {
            this.boatService = boatService;
        }
        // GET: api/<BoatController>
        [HttpGet]
        public ActionResult<List<Boat>> Get()
        {
            return boatService.GetBoats();
        }

        // GET api/<BoatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BoatController>
        [HttpPost]
        public ActionResult Post([FromBody] Boat boat)
        {
            boatService.Create(boat);
            return CreatedAtAction(nameof(Get), new { id = boat.Id }, boat);
        }
    }
}
