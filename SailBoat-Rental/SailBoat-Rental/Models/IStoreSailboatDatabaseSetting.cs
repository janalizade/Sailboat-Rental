namespace Sailboat_Rental.Models
{
    public interface IStoreSailboatDatabaseSetting
    {
        string SailBoatCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        
    }
}
