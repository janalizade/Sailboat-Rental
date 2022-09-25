using SailBoat_Rental.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sailboat_Rental.Model;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text.Json;

namespace SailBoat_Rental.Repository
{
    public class BookingRepository
    {
        private readonly IMongoCollection<Booking> _bookings;

        public BookingRepository(IOptions<StoreSailboatDatabaseSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _bookings = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Booking>("booking");

            CreateIndex();
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
            return _bookings.Find(this.QueryByLessorIdAndBookingId(lessorId, bookingId)).First();
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
                .Set(booking => booking.HandoverDate, DateTime.Now)
                .Set(booking => booking.Price, price);
            
            var query = this.QueryByLessorIdAndBookingId(lessorId, bookingId);
            
            this._bookings.UpdateOne(query, update);      
        }
        
        public async Task<AggregatedBooking> getAggregatedBooking(string lessorId, string bookingId)
        {
            var pipeline = GetPipelineDefinition(lessorId, bookingId);
            var bsonDocument = await this._bookings.Aggregate(pipeline).FirstOrDefaultAsync();
            return this.Convert(bsonDocument);
        }
      

        private AggregatedBooking Convert(BsonDocument document)
        {
            var id  = document.GetElement("_id").Value.ToString();
            var bookingNumber = document.GetElement("bookingNumber").Value.ToString();
            var handoverDate  = ((DateTime)document.GetElement("handoverDate").Value);
            var personNumber = document.GetElement("personNumber").Value.ToString();
            var boatId = document.GetElement("boatId").Value.ToString();
            var lessorId = document.GetElement("lessorId").Value.ToString();
            var categoryId = document.GetElement("categoryId").Value.ToString();
            var returnDate = ((DateTime)document.GetElement("returnDate").Value);
            var status = document.GetElement("status").Value.ToString();
            var boatNumber = document.GetElement("boatNumber").Value.ToString();
            var categoryName = document.GetElement("categoryName").Value.ToString();
            var basicFee = document.GetElement("basicFee").Value.ToDouble();
            var hourlyRate = document.GetElement("hourlyRate").Value.ToDouble();

            var aggregatedBooking = new AggregatedBooking();

            aggregatedBooking.Id = id;
            aggregatedBooking.BookingNumber = bookingNumber;
            aggregatedBooking.HandoverDate = handoverDate;
            aggregatedBooking.PersonNumber = personNumber;
            aggregatedBooking.BoatId = boatId;
            aggregatedBooking.HourlyRate = hourlyRate;
            aggregatedBooking.LessorId = lessorId;
            aggregatedBooking.CategoryId = categoryId;
            aggregatedBooking.ReturnDate = returnDate;
            aggregatedBooking.Status = BookingStatus.INUSE;
            aggregatedBooking.BoatNumber = boatNumber;
            aggregatedBooking.BasicFee = basicFee;
            aggregatedBooking.HourlyRate= hourlyRate;
            aggregatedBooking.CategoryName = categoryName;

            return aggregatedBooking;
        }


        private PipelineDefinition<Booking, BsonDocument> GetPipelineDefinition(string lessorId, string bookingId)
        {
            return new BsonDocument[] { };
        }

       private PipelineDefinition<Booking, BsonDocument> GetPipelineDefinition_(string lessorId, string bookingId)
        {
           return new BsonDocument[]{
    new BsonDocument("$match",
    new BsonDocument("$and",
    new BsonArray
            {
                new BsonDocument("lessorId",
                new BsonDocument("$eq",
                new ObjectId(lessorId))),
                new BsonDocument("_id",
                new BsonDocument("$eq",
                new ObjectId(bookingId)))
            })),
    new BsonDocument("$lookup",
    new BsonDocument
        {
            { "from", "category" },
            { "localField", "categoryId" },
            { "foreignField", "_id" },
            { "as", "category" }
        }),
    new BsonDocument("$unwind",
    new BsonDocument("path", "$category")),
    new BsonDocument("$lookup",
    new BsonDocument
        {
            { "from", "boat" },
            { "localField", "boatId" },
            { "foreignField", "_id" },
            { "as", "boat" }
        }),
    new BsonDocument("$unwind",
    new BsonDocument("path", "$boat")),
    new BsonDocument("$project",
    new BsonDocument
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
        })
};


            
        }

    }
}
