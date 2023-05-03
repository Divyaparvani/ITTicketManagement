using ITMS.Model.Models;
using ITMS.Model.ViewModels;

namespace ITMS.Services.Interface
{
    public  interface ILoginService 
    {
        Users Login(AccountViewModel model);
    }
}
