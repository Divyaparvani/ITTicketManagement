using ITMS.Model.Models;
using System.Data.Entity;

namespace ITMS.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
           : base("DefaultConnection")
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Tests> Tests { get; set; }

    }
   
}

