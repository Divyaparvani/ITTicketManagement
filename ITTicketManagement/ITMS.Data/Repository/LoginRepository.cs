using ITMS.Data.Infrastructure;
using ITMS.Data.Interface;
using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;

namespace ITMS.Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext Context;

        public LoginRepository(DataContext context)
        {
            this.Context = context;
        }

        public Users Login(AccountViewModel model)
        {
            var user = Context.Users.Where(User => User.Email == model.Email && User.Password == model.password && !User.IsDeleted).FirstOrDefault();
            return user;

        }
        
    }
}
