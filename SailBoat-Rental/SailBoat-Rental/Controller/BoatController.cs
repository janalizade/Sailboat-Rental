using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Model;
using SailBoat_Rental.Service;

namespace SailBoat_Rental.Controller
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
            return this.boatService.GetBoats();
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
            this.boatService.Create(boat);
            return CreatedAtAction(nameof(Get), new { id = boat.Id }, boat);
        }
    }
}
