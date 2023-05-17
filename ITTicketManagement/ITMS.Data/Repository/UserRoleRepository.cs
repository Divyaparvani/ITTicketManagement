using ITMS.Data.Infrastructure;
using ITMS.Data.Interface;
using ITMS.Model.Models;
using System;
using System.Linq;

namespace ITMS.Data.Repository
{
    public class UserRoleRepository : Repository<UserRole>,IUserRoleRepository
    {
        public UserRoleRepository(DataContext context) : base(context)
        {

        }
        public void AddUserRole(UserRole userRoles)
        {
            Add(userRoles);
        }

        public void UpdateUserRole(UserRole userRole)
        {
            Update(userRole);
        }
    
        public UserRole GetUserRole( Guid userId)
        {
            return _dbSet.Where(x => x.UserId == userId).FirstOrDefault();
        }
    }
}
