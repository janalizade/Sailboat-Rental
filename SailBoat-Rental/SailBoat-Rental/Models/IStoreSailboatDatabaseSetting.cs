namespace Sailboat_Rental.Models
{
    public interface IStoreSailboatDatabaseSetting
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
       
        
        
    }
}
