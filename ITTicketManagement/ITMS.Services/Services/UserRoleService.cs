using ITMS.Data.Interface;
using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using ITMS.Services.Interface;

namespace ITMS.Services.Services
{
    public class UserRoleService : IUserRoleService
    {
        IUserRoleRepository _userRoleRepository;
        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public void CreateUserRole(UserViewModel model)
        {
            UserRole User = new UserRole
            {
                RoleId = model.RoleId,
                UserId = model.Id
            };
            _userRoleRepository.AddUserRole(User);
        }
        public void UpdateUserRole(UserViewModel model)
        {
            UserRole userRoleForUpdate = _userRoleRepository.GetUserRole(model.Id);
            userRoleForUpdate.RoleId = model.RoleId;
            userRoleForUpdate.UserId = model.Id;
            _userRoleRepository.UpdateUserRole(userRoleForUpdate);

        }
    }
}
