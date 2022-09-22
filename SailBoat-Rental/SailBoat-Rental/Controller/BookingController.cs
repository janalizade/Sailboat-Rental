using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Model;
using SailBoat_Rental.Service;


namespace SailBoat_Rental.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase

    {

        private readonly BookingService bookingService;
        public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }
       
        [HttpGet("lessorId/{lessorId}/")]
        public ActionResult<List<Booking>> Get(string lessorId)
        {
            return bookingService.GetBookings();
        }

      
        [HttpGet("lessorId/{lessorId}/boatId/{boatId}")]
        public string Get(string lessorId, string boatId)
        {
            return "value";
        }

        [HttpPost("lessorId/{lessorId}")]
        public ActionResult<Booking> Post(string lessorId,[FromBody] Booking booking)
        {
          return bookingService.Create(booking);
        }
    }
}
