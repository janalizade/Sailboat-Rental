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
            float BasicFee = 0f;
            float HourlyRate = 0f;
            CalculatorArgs args = new CalculatorArgs(BasicFee, HourlyRate, booking.HandoverDate, DateTime.Now);
            CalculatorFactory calculatorFactory = new CalculatorFactory();
            AbstractCalculator calculator = calculatorFactory.GetCalculator(booking.CategoryName);
            return calculator.Calculate(args);
        }

    }
}
