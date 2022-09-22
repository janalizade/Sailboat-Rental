using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Model;
using SailBoat_Rental.Service;

namespace SailBoat_Rental.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LessorController : ControllerBase
    {
        private readonly LessorService lessorService;
        public LessorController(LessorService lessorService)
        {
            this.lessorService = lessorService;
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<List<Lessor>> GetAll()
        {
            return this.lessorService.GetLessors();
        }


        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<Lessor> Create([FromBody] Lessor lessor)
        {
            return this.lessorService.Create(lessor);
        }
    }
}
