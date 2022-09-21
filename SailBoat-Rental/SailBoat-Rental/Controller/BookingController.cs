using Microsoft.AspNetCore.Mvc;
using Sailboat_Rental.Model;
using SailBoat_Rental.Service;


namespace SailBoat_Rental.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase

    {

        private readonly BookingService bookingService;
        public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public ActionResult<List<Booking>> Get()
        {
            return bookingService.GetBookings();
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingController>
        [HttpPost]
        public ActionResult Post([FromBody] Booking booking)
        {
            bookingService.Create(booking);
            return CreatedAtAction(nameof(Get), new { id = booking.Number }, booking);
        }


    }
}
