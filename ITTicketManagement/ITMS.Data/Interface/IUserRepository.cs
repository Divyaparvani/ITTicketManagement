using ITMS.Data.Infrastructure;
using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using System;
using System.Collections.Generic;

namespace ITMS.Data.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserById(Guid id);
        void CreateUser(User users);
        void UpdateUser(User user);
        List<UserViewModel> GetAllUsers();
        UserViewModel GetUserForEdit(Guid id);
    }
}
