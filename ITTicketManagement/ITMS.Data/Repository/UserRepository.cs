using ITMS.Data.Infrastructure;
using ITMS.Data.Interface;
using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITMS.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }

        public User GetUserById(Guid id)
        {
            return GetById(id);
        }

        public void CreateUser(User users)
        {
            Add(users);
        }

        public void UpdateUser(User users)
        {
            Update(users);
        }

        public List<UserViewModel> GetAllUsers()
        {
            return (from u in _dbSet
                    join ur in _context.UserRoles
                    on u.Id equals ur.UserId
                    join r in _context.Roles 
                    on ur.RoleId equals r.Id
                    where !u.IsDeleted && !ur.IsDeleted && !r.IsDeleted
                    orderby u.CreatedOn descending
                    select new UserViewModel()
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Password = u.Password,
                        RoleId = ur.RoleId,
                        RoleName = r.Name,
                        UserName = u.UserName,
                        Gender = u.Gender,
                        MobileNo = u.MobileNo
                    }).ToList();
        }

        public UserViewModel GetUserForEdit(Guid id)
        {
            return (from u in _dbSet
                    join ur in _context.UserRoles 
                    on u.Id equals ur.UserId
                    where !u.IsDeleted && !ur.IsDeleted && u.Id == id
                    select new UserViewModel()
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        RoleId = ur.RoleId,
                        Email = u.Email,
                        UserName = u.UserName,
                        MobileNo = u.MobileNo,
                        Gender = u.Gender
                    }).FirstOrDefault();
        }

    }
}
