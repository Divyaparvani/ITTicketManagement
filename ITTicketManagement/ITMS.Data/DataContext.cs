using System.Data.Entity;

namespace ITMS.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
           : base("Defaultconnection")
        {
        }
    }
}
