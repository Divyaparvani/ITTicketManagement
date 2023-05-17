using ITMS.Model.ViewModels;

namespace ITMS.Services.Interface
{
    public interface IUserRoleService
    {
        void CreateUserRole(UserViewModel model);
        void UpdateUserRole(UserViewModel model);

    }
}