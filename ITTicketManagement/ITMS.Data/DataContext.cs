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
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Tests> Tests { get; set; }

    }
   
}

