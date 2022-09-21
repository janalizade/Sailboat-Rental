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

        public List<Booking> GetBookings()
        {
            return this.bookingRepository.GetBookings();
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
