namespace Sailboat_Rental.Models
{
    public interface IStoreSailboatDatabaseSetting
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string LessorCollectionName { get; set; }

        string CategoryCollectionName { get; set; }
        string BoatCollectionName { get; set; }
        string BookingCollectionName { get; set; }
         

    }
}
