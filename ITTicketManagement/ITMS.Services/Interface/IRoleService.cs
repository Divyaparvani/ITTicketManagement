using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using System;
using System.Collections.Generic;

namespace ITMS.Services.Interface
{
    public interface IRoleService
    {
        RoleViewmodel GetRole(Guid Id);
        string CreateRole(RoleViewmodel role);
        List<Roles> GetRoleList();
        string UpdateRole(RoleViewmodel model);
        void RemoveRole(Guid Id);
    }
}
