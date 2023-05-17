using ITMS.Model.Models;
using System;

namespace ITMS.Data.Interface
{
    public  interface IUserRoleRepository
    {
        void AddUserRole(UserRole userRoles);
        void UpdateUserRole (UserRole userRole);
        UserRole GetUserRole(Guid userId);
    }
}
