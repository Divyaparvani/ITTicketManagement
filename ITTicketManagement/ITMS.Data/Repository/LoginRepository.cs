using ITMS.Data.Interface;
using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using System.Linq;

namespace ITMS.Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext Context;

        public LoginRepository(DataContext context)
        {
            this.Context = context;
        }

        public User Login(AccountViewModel model)
        {
            return Context.Users.Where(User => User.Email == model.Email && User.Password == model.password && !User.IsDeleted).FirstOrDefault();
        }
    }
}
