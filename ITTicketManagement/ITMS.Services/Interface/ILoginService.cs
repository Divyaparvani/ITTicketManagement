using ITMS.Model.Models;
using ITMS.Model.ViewModels;

namespace ITMS.Services.Interface
{
    public  interface ILoginService 
    {
        User Login(AccountViewModel model);
    }
}
