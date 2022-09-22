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
        [Produces("application/json")]
        public ActionResult<List<Boat>> GetAll(string lessorId)
        {
            return this.boatService.GetBoats();
        }
 
        [HttpGet("lessorId/{lessorId}/boatId/{boatId}")]
        [Produces("application/json")]
        public string GetOne(string lessorId, string boatId)
        {
            Console.WriteLine("id: " + boatId);
            Console.WriteLine("lessorId: " + lessorId);
            return "value";
        }

        
        [HttpPost("lessorId/{lessorId}")]
        public ActionResult<Boat> Post(string lessorId,[FromBody] Boat boat)
        {
            return this.boatService.Create(boat);
        }
    }
}
