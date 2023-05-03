using ITMS.Data.Infrastructure;
using ITMS.Model.Models;
using ITMS.Model.ViewModels;

namespace ITMS.Data.Interface
{
    public interface ILoginRepository 
    {
       Users Login(AccountViewModel model);
    }
}
