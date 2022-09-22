using SailBoat_Rental.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sailboat_Rental.Model;
using System.Collections.Generic;

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

       private FilterDefinition<Booking> dynamicQuery(Dictionary<string, string> queryParams)
        {
            var filters = new List<FilterDefinition<Booking>>();
            for (int index = 0; index < queryParams.Count; index++)
            {
              var param = queryParams.ElementAt(index);
              filters.Add(Builders<Booking>.Filter.Eq(param.Key, param.Value));
            }
            return Builders<Booking>.Filter.And(filters);
        }

        public List<Booking> GetBookings(Dictionary<string, string> queryParams)
        {
            return _bookings.Find(this.dynamicQuery(queryParams)).ToList();
        }

        public List<Booking> GetBookings(string lessorId)
        {
            var lessorFilter = Builders<Booking>.Filter.Eq(booking => booking.LessorId, lessorId);
            return _bookings.Find(lessorFilter).ToList();
        }

        public Booking GetBooking(string lessorId, string bookingId)
        {
            var lessorFilter = Builders<Booking>.Filter.Eq(booking => booking.LessorId, lessorId);
            var bookingFilter = Builders<Booking>.Filter.Eq(booking => booking.Id, bookingId);
            var andFilter = Builders<Booking>.Filter.And(lessorFilter, bookingFilter);
            return _bookings.Find(andFilter).First();
        }

        
        public AggregatedBooking getBookingByNumber(int bookingNumber)
        {
            return new AggregatedBooking();
        }

    }
}
