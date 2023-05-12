using ITMS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITMS.Data.Interface
{
   public  interface IRoleRepository 
    {
        void Add(Roles roles);
        void SaveChanges();
        Roles GetById(Guid Id);
        IQueryable<Roles> GetAll();
        IQueryable<Roles> GetWithWhere(Expression<Func<Roles, bool>> where);
        void Update(Roles roles);
        void Delete(Guid Id, bool autoSave);
    }
}
