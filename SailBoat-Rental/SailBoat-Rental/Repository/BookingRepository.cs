using SailBoat_Rental.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sailboat_Rental.Model;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace SailBoat_Rental.Repository
{
    public class BookingRepository
    {
        private readonly IMongoCollection<Booking> _bookings;

        private readonly IMongoDatabase _db;

        public BookingRepository(IOptions<StoreSailboatDatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _bookings = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Booking>("booking");

            this._db = mongoClient.GetDatabase(options.Value.DatabaseName);

           // CreateIndex();
        }

        private async void CreateIndex()
        {
            await _bookings.Indexes.CreateOneAsync(new CreateIndexModel<Booking>(Builders<Booking>.IndexKeys.Ascending(booking => booking.BookingNumber), new CreateIndexOptions { Unique = true }));
        }
        public Booking Create(Booking booking)
        {
            this._bookings.InsertOne(booking);
            return booking;
        }
        public Booking CreateOne(Booking booking)
        {
            this._bookings.InsertOne(booking);
            return booking;
        }
        private FilterDefinition<Booking> dynamicQuery(Dictionary<string, string> queryParams)
        {
            var filters = new List<FilterDefinition<Booking>>();
            for (int index = 0; index < queryParams.Count; index++)
            {
                var param = queryParams.ElementAt(index);
                var key = param.Key;
                var value = param.Value;

                if(key.EndsWith("Id"))
                {
                    filters.Add(Builders<Booking>.Filter.Eq(key, new BsonObjectId(value)));
                }
                else
                {
                    filters.Add(Builders<Booking>.Filter.Eq(key, value));
                }                 
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
            return _bookings.Find(this.QueryByLessorIdAndBookingId(lessorId, bookingId)).First();
        }


        public Booking GetBookingLinque(string lessorId, string bookingId)
        {
            IMongoQueryable<Booking> results =
                        from booking in _bookings.AsQueryable()
                        where 
                        booking.LessorId == lessorId && 
                        booking.Id == bookingId 
                        select booking;
            return results.First();
        }


        private FilterDefinition<Booking> QueryByLessorIdAndBookingId(string lessorId, string bookingId)
        {
            var lessorFilter = Builders<Booking>.Filter.Eq(booking => booking.LessorId, lessorId);
            var bookingFilter = Builders<Booking>.Filter.Eq(booking => booking.Id, bookingId);
            return Builders<Booking>.Filter.And(lessorFilter, bookingFilter);
        }




        public void CancelBooking(string lessorId, string bookingId)
        {
            var update = Builders<Booking>
                .Update
                .Set(booking => booking.Status, BookingStatus.CANCELLED);

            var query = this.QueryByLessorIdAndBookingId(lessorId, bookingId);

            this._bookings.UpdateOne(query, update);
        }

        public void ReturnBoat(string lessorId, string bookingId, double price)
        {
            var update = Builders<Booking>
                .Update
                .Set(booking => booking.Status, BookingStatus.RETURENED)
                .Set(booking => booking.ReturnDate, DateTime.Now)
                .Set(booking => booking.Price, price);

            var query = this.QueryByLessorIdAndBookingId(lessorId, bookingId);

            this._bookings.UpdateOne(query, update);
        }

        public AggregatedBooking getAggregatedBooking(string lessorId, string bookingId)
        {
            var aggregate = this._bookings

                .Aggregate()

                .Match(new BsonDocument("$and",
                    new BsonArray {
                        new BsonDocument("lessorId",
                        new BsonDocument("$eq",
                        new ObjectId(lessorId))),
                        new BsonDocument("_id",
                        new BsonDocument("$eq",
                        new ObjectId(bookingId)))
                    })
                )

                .Lookup(foreignCollectionName: "category",
                        localField: "categoryId",
                        foreignField: "_id",
                        @as: "category")

                .Unwind(field: "category")

                 .Lookup(foreignCollectionName: "boat",
                         localField: "boatId",
                         foreignField: "_id",
                         @as: "boat")

                 .Unwind(field: "boat")

                 .Project<AggregatedBooking>(new BsonDocument
                 {
                    { "bookingNumber", 1 },
                    { "handoverDate", 1 },
                    { "personNumber", 1 },
                    { "boatId", 1 },
                    { "lessorId", 1 },
                    { "categoryId", 1 },
                    { "returnDate", 1 },
                    { "status", 1 },
                    { "boatNumber", "$boat.number" },
                    { "categoryName", "$category.categoryname" },
                    { "basicFee", "$category.basicFee" },
                    { "hourlyRate", "$category.hourlyRate" }
                 });

            Console.WriteLine(aggregate);

              return  aggregate.SingleOrDefault();
        }
    }

}

