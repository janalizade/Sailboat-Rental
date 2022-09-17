
namespace Sailboat_Rental.Models
{
    public class StoreSailboatDatabaseSetting:IStoreSailboatDatabaseSetting
    {
        public string ConnectionString { get; set; } = String.Empty;
       
      
        public string DatabaseName { get; set; }=String.Empty ;
        public string CollectionName { get; set; } = String.Empty;

    }
}
