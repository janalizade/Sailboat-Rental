using Sailboat_Rental.Models;
using SailBoat_Rental.Models;
using SailBoat_Rental.Repository;
using SailBoat_Rental.Services.Calculator;

namespace SailBoat_Rental.Services
{
    public class BookingService
    {
        private BookingRepository bookingRepository;
        public float ReturnBoat(int BoatNumber)
        {
            AggregatedBooking booking = bookingRepository.getBookingByNumber(BoatNumber); 
            CalculatorFactory calculatorFactory = new CalculatorFactory();
            AbstractCalculator calculator = calculatorFactory.GetCalculator(booking.CategoryName);

            CalculatorArgs args = new CalculatorArgs(booking.BasicFee, booking.HourlyRate, booking.HandoverDate, DateTime.Now);
            return calculator.Calculate(args);
        }

    }
}
