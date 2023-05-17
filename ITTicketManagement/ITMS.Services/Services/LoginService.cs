using ITMS.Data.Interface;
using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using ITMS.Services.Interface;

namespace ITMS.Services.Services
{

    public class LoginService : ILoginService
    {
        ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public User Login(AccountViewModel model)
        {
           return _loginRepository.Login(model);
        }
    }
}

