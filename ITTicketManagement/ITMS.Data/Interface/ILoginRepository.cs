using ITMS.Model.Models;
using ITMS.Model.ViewModels;

namespace ITMS.Data.Interface
{
    public interface ILoginRepository 
    {
       User Login(AccountViewModel model);
    }
}
