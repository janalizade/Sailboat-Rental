using SailBoat_Rental.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sailboat_Rental.Model;

namespace SailBoat_Rental.Repository
{
    public class BookingRepository
    {
        private readonly IMongoCollection<Booking> _bookings;
        public BookingRepository(IOptions<StoreSailboatDatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _bookings = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Booking>(options.Value.BookingCollectionName);

            CreateIndex();
        }

        private async void CreateIndex()
        {
            await _bookings.Indexes.CreateOneAsync(new CreateIndexModel<Booking>(Builders<Booking>.IndexKeys.Ascending(booking => booking.Number), new CreateIndexOptions { Unique = true }));
        }
        public Booking Create(Booking booking)
        {
            _bookings.InsertOne(booking);
            return booking;
        }


        public List<Booking> GetBookings()
        {
            return _bookings.Find(booking => true).ToList();
        }
        public AggregatedBooking getBookingByNumber(int bookingNumber)
        {
            return new AggregatedBooking();
        }

    }
}
