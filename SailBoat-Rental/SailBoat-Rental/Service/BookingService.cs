using Sailboat_Rental.Model;
using SailBoat_Rental.Model;
using SailBoat_Rental.Repository;
using SailBoat_Rental.Service.Calculator;

namespace SailBoat_Rental.Service
{
    public class BookingService
    {
        private BookingRepository bookingRepository;
        private BoatRepository boatRepository;

        public BookingService(BookingRepository bookingRepository, BoatRepository boatRepository)
        {
            this.bookingRepository = bookingRepository;
            this.boatRepository = boatRepository;
        }
       
        public Booking BookByBoatId(string lessorId, string categoryId, string boatId, BookingRegistration bookingRegistration)
        {
            var booking = new Booking(lessorId, categoryId, boatId, bookingRegistration.BookingNumber, bookingRegistration.PersonNumber, bookingRegistration.HandoverDate);
            booking.Status = BookingStatus.INUSE;
            return this.bookingRepository.Create(booking);
        }
        public Booking BookByBoatNumber(string lessorId, string categoryId, string boatNumber, BookingRegistration bookingRegistration)
        {
            var boatId = this.boatRepository.GetBoatByNumber(lessorId, boatNumber).Id;
            var booking = new Booking(lessorId, categoryId, boatId, bookingRegistration.BookingNumber, bookingRegistration.PersonNumber, bookingRegistration.HandoverDate);
            return this.bookingRepository.CreateOne(booking);
        }

        public Booking GetBooking(string lessorId, string bookingId)
        {
            return bookingRepository.GetBooking(lessorId, bookingId);
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
       
        public AggregatedBooking ReturnBoatAndCalculatePrice(string lessorId, string bookingId)
        {
            var aggregatedBooking = this.bookingRepository.getAggregatedBooking(lessorId, bookingId); 
            var calculatorFactory = new CalculatorFactory();
            var calculator = calculatorFactory.GetCalculator(aggregatedBooking.CategoryName);

            var calculatorArgs = new CalculatorArgs(aggregatedBooking.BasicFee, aggregatedBooking.HourlyRate, aggregatedBooking.HandoverDate, aggregatedBooking.ReturnDate);

            var price = calculator.Calculate(calculatorArgs);

            aggregatedBooking.Price = price;

            this.bookingRepository.ReturnBoat(lessorId, bookingId, price);

            return aggregatedBooking;
        }

        public void CancelBooking(string lessorId, string bookingId)
        {
            this.bookingRepository.CancelBooking(lessorId, bookingId);
        }

    }
}
