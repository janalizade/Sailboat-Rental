
namespace Sailboat_Rental.Models
{
    public class StoreSailboatDatabaseSetting:IStoreSailboatDatabaseSetting
    {
        public string SailBoatCollectionName { get; set; }=String.Empty;
        public string ConnectionString { get; set; }=String.Empty ;
        public string DatabaseName { get; set; }=String.Empty ;

    }
}
