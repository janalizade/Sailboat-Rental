
namespace Sailboat_Rental.Models
{
    public class StoreSailboatDatabaseSetting:IStoreSailboatDatabaseSetting
    {
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; }=String.Empty ;
        public string LessorCollectionName { get; set; } = String.Empty;
        public string CategoryCollectionName { get; set; } = String.Empty;
        public string BoatCollectionName { get; set; } = String.Empty;
        public string BookingCollectionName { get; set; } = String.Empty;

    }
}
