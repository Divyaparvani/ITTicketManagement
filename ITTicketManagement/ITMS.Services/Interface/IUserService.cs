using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using System;
using System.Collections.Generic;

namespace ITMS.Services.Interface
{
    public interface IUserService
    {
        string CreateUser(UserViewModel model);
        void UpdateUser(UserViewModel model);
        void DeleteUser(Guid id);
        List<UserViewModel> GetAllUsers();
        UserViewModel GetUserForEdit(Guid id);
        List<DropDown> GetRolesForDropDown();
        
    }
}
