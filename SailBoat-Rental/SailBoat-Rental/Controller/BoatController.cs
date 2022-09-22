using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Model;
using SailBoat_Rental.Service;

namespace SailBoat_Rental.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        private readonly BoatService boatService;
        public BoatController(BoatService boatService)
        {
            this.boatService = boatService;
        }
        // GET: api/<BoatController>
        [HttpGet("lessorId/{lessorId}")]
        public ActionResult<List<Boat>> Get(string lessorId)
        {
            return this.boatService.GetBoats();
        }
 
        [HttpGet("lessorId/{lessorId}/boatId/{boatId}")]
        public string Get(string lessorId, string boatId)
        {
            Console.WriteLine("id: " + boatId);
            Console.WriteLine("lessorId: " + lessorId);
            return "value";
        }

        
        [HttpPost("lessorId/{lessorId}")]
        public ActionResult Post(string lessorId,[FromBody] Boat boat)
        {
            this.boatService.Create(boat);
            return CreatedAtAction(nameof(Get), new { id = boat.Id }, boat);
        }
    }
}
