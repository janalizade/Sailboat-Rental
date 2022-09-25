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
       
        [HttpGet("lessors/{lessorId}/")]
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

      
        [HttpGet("lessors/{lessorId}/bookings/{bookingId}")]
        [Produces("application/json")]
        public ActionResult<Booking> GetBooking(
            string lessorId, 
            string bookingId
            )
        {
            return bookingService.GetBooking(lessorId, bookingId);
        }

        
        [HttpPost("lessors/{lessorId}/categories/{categoryId}/boats/boatNumber/{boatNumber}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<Booking> BookByBoatNumber(string lessorId, string categoryId, string boatNumber, [FromBody] BookingRegistration bookingRegistration)
        {
            return bookingService.BookByBoatNumber(lessorId, categoryId, boatNumber, bookingRegistration);
        }
        /**
         * 
         * new boat registration
         * 
         * **/
        [HttpPost("lessors/{lessorId}/categories/{categoryId}/boats/{boatId}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<Booking> BookByBoatId(string lessorId, string categoryId, string boatId, [FromBody] BookingRegistration bookingRegistration)
        {
            return bookingService.BookByBoatId(lessorId, categoryId, boatId, bookingRegistration);
        }
        /**
         * 
         * return the boat and calculate the price
         * 
         * **/
        [HttpPost("lessors/{lessorId}/bookings/{bookingId}")]
        [Produces("text/plain")]
        [Consumes("text/plain")]
        public async Task<ActionResult<double>> ReturnBoatAndCalculatePrice(string lessorId, string bookingId)
        {
            return await bookingService.ReturnBoatAndCalculatePrice(lessorId, bookingId);
        }

        [HttpDelete("lessors/{lessorId}/bookings/{bookingId}")]
        public void CancelBooking(string lessorId, string bookingId)
        {
            bookingService.CancelBooking(lessorId, bookingId);
        }

        
    }
}
