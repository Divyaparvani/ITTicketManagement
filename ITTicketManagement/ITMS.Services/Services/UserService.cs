using ITMS.Data.Interface;
using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using ITMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITMS.Services.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IUserRoleService _userRoleService;
        IRoleService _roleService;
        public UserService(IUserRepository UserRepository,
                            IUserRoleService userRoleService,
                            IRoleService roleService)
        {
            _userRepository = UserRepository;
            _userRoleService = userRoleService;
            _roleService = roleService;
        }

        public List<UserViewModel> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public string CreateUser(UserViewModel model)
        {
            if (_userRepository.GetAllUsers().Where(x => x.UserName == model.UserName && !x.IsDeleted).Any())
            {
               return "Name already exist";
            }
            if (_userRepository.GetAllUsers().Where(x => x.Email == model.Email && !x.IsDeleted).Any())
            {
                return "Code already exist";
            }

            User userForCreate = new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MobileNo = model.MobileNo,
                Password = model.Password,
                UserName = model.UserName,
                Gender = model.Gender,
                Email = model.Email
            };
            _userRepository.CreateUser(userForCreate);
            _userRoleService.CreateUserRole(model);
            return "success";
        }

        public void DeleteUser(Guid id)
        {
            User user = _userRepository.GetUserById(id);
            user.IsDeleted = true;
            _userRepository.UpdateUser(user);
        }

        public UserViewModel GetUserForEdit(Guid id)
        {
            var user = _userRepository.GetUserForEdit(id);
            user.RoleDropDown = GetRolesForDropDown();
            return user;
        }
        public void UpdateUser(UserViewModel model)
        {
            User userForUpdate = _userRepository.GetById(model.Id);
            userForUpdate.FirstName = model.FirstName;
            userForUpdate.LastName = model.LastName;
            userForUpdate.MobileNo = model.MobileNo;
            userForUpdate.Password = model.Password;
            userForUpdate.UserName = model.UserName;
            userForUpdate.Gender = model.Gender;
            userForUpdate.Email = model.Email;
            
            _userRepository.UpdateUser(userForUpdate);
            _userRoleService.UpdateUserRole(model);

        }
      
        public List<DropDown> GetRolesForDropDown()
        {
            return _roleService.GetRoleList().Select(x => new DropDown() { Id = x.Id, Name = x.Name }).ToList();
        }
    }
}