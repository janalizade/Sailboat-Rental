using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Model;
using SailBoat_Rental.Model;
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
        [Produces("application/json")]
        public ActionResult<List<Booking>> GetBookingsByParameters(
            string lessorId, 
            string bookNumber,
            string personNumber,
            BookingStatus bookingStatus
            )
        {
            return bookingService.GetBookings(lessorId, bookNumber, personNumber, bookingStatus);
        }

      
        [HttpGet("lessorId/{lessorId}/bookingId/{bookingId}")]
        [Produces("application/json")]
        public ActionResult<Booking> GetBooking(
            string lessorId, 
            string bookingId
            )
        {
            return bookingService.GetBooking(lessorId, bookingId);
        }

        [HttpPost("lessorId/{lessorId}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<Booking> Create(
             string lessorId,
             [FromBody] Booking booking
             )
        {
            return bookingService.Create(booking);
        }

        [HttpPost("lessorId/{lessorId}/bookingId/{bookingId}")]
        public ActionResult<double> ReturnBoatAndCalculatePrice(
            string lessorId,
            string bookingId
            )
        {
            return bookingService.ReturnBoatAndCalculatePrice(lessorId, bookingId);
        }

    }
}
