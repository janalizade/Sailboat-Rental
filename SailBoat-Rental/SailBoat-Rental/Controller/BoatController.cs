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
 
        

        [HttpGet("lessorId/{lessorId}/categoryId/{categoryId}")]
        [Produces("application/json")]
        public ActionResult<List<Boat>> GetOne(
           string lessorId,
           string categoryId
           )
        {
            return boatService.GetBoat(lessorId, categoryId);
        }

     

        [HttpPost("lessorId/{lessorId}/categoryId/{categoryId}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<Boat> Post(string lessorId, string categoryId,[FromBody] Boat boat)
        {
            boat.LessorId = lessorId;
            boat.CategoryId = categoryId;
            return this.boatService.Create(boat);
        }
    }
}
