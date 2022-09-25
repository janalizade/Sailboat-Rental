using Sailboat_Rental.Model;
using SailBoat_Rental.Model;
using SailBoat_Rental.Repository;
using SailBoat_Rental.Service.Calculator;

namespace SailBoat_Rental.Service
{
    public class BookingService
    {
        private BookingRepository bookingRepository;

        public BookingService(BookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
       
        public Booking Create(string lessorId, Booking booking)
        {
            booking.LessorId = lessorId;
            return this.bookingRepository.Create(booking);
        }
        public Booking GetBooking(string lessorId, string bookingId)
        {
            return bookingRepository.GetBooking(lessorId, bookingId);
        }

        public List<Booking> GetBookings_(string lessorId)
        {
            return bookingRepository.GetBookings(lessorId);
        }

        public List<Booking> GetBookings(string lessorId, string bookNumber, string personNumber, BookingStatus bookingStatus)
        {
            var queryParams = new Dictionary<string, string>();
            
            queryParams.Add("lessorId", lessorId);

            if (!string.IsNullOrWhiteSpace(bookNumber))
            {
                queryParams.Add("bookNumber", bookNumber);
            }
            if (!string.IsNullOrWhiteSpace(personNumber))
            {
                queryParams.Add("personNumber", personNumber);
            }
            if (BookingStatus.UNDEFINED!= bookingStatus)
            {
                queryParams.Add("bookingStatus", bookingStatus.ToString());
            }
            return this.bookingRepository.GetBookings(queryParams);
        }
       
        public double ReturnBoatAndCalculatePrice(string lessorId, string bookingId)
        {
            var aggregatedBooking = this.bookingRepository.getAggregatedBooking(lessorId, bookingId); 
            var calculatorFactory = new CalculatorFactory();
            var calculator = calculatorFactory.GetCalculator(aggregatedBooking.CategoryName);

            var args = new CalculatorArgs(
                aggregatedBooking.BasicFee, 
                aggregatedBooking.HourlyRate, 
                aggregatedBooking.HandoverDate, 
                aggregatedBooking.ReturnDate);

            return calculator.Calculate(args);
        }
    }
}
