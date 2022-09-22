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
       
        public Booking Create(Booking booking)
        {
            return this.bookingRepository.Create(booking);
        }
        public Booking GetBooking(string lessorId, string bookingId)
        {
            return bookingRepository.GetBooking(lessorId, bookingId);
        }
        public List<Booking> GetBookings(string lessorId)
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
       
        public float ReturnBoat(int BoatNumber)
        {
            AggregatedBooking booking = this.bookingRepository.getBookingByNumber(BoatNumber); 
            CalculatorFactory calculatorFactory = new CalculatorFactory();
            AbstractCalculator calculator = calculatorFactory.GetCalculator(booking.CategoryName);

            CalculatorArgs args = new CalculatorArgs(booking.BasicFee, booking.HourlyRate, booking.HandoverDate, DateTime.Now);
            return calculator.Calculate(args);
        }
       


    }
}
